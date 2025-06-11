
using Microsoft.AspNetCore.Mvc;
using SpClima.Data;
using SpClima.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text; 

namespace SpClima.Controllers
{
    [Authorize(Roles = "Administrador")] // Secure the controller for Admins only
    public class PedidoController : Controller
    {
        private readonly AppDbContext _context;

        public PedidoController(AppDbContext context)
        {
            _context = context;
        }

        // POST: /Pedido/Create (Original functionality - Keep as is, but maybe add Authorization? No, it's public facing)
        [HttpPost]
        [AllowAnonymous] // Allow anonymous users to create orders
        public IActionResult Create(Pedido pedido)
        {
            // Add basic server-side validation for price if needed, or set it here
            var variacao = _context.ItemVariacoes.FirstOrDefault(v => v.Id == pedido.ItemVariacaoId);
            if (variacao != null)
            {
                pedido.Preco = variacao.Preco; // Set price from variation
            }
            else
            {
                // Handle case where variation is not found - maybe return error?
                ModelState.AddModelError("", "Variação do item não encontrada.");
            }

            if (ModelState.IsValid)
            {
                var item = _context.items.FirstOrDefault(i => i.Id == pedido.ItemId);
                // Variation already fetched

                _context.Pedidos.Add(pedido);
                _context.SaveChanges();

                // Construct WhatsApp message (ensure Item and Variacao are not null)
                var itemTitulo = item?.Titulo ?? "Item não encontrado";
                var variacaoNome = variacao?.Nome ?? "Variação não encontrada";
                var mensagem = $"Olá, sou {pedido.ClienteNome}. Quero orçamento sobre: {itemTitulo}\n" +
                               $"Variação: {variacaoNome}\nEndereço: {pedido.ClienteEndereco}\nTelefone: {pedido.ClienteTelefone}";

                var url = $"https://wa.me/5514997576049?text={Uri.EscapeDataString(mensagem)}";

                // Maybe show a success message before redirecting?
                // TempData["SuccessMessage"] = "Pedido enviado com sucesso! Entraremos em contato.";
                return Redirect(url);
            }

            // If ModelState is invalid, redisplay the form or redirect with error
            // Redirecting back to gallery might lose user input and error messages.
            // Consider returning to the specific item page or showing errors differently.
            TempData["ErrorMessage"] = "Erro ao processar o pedido. Verifique os dados e tente novamente.";
            // Need the original page context to return correctly, GaleriaOrcamento might not be right
            // This depends heavily on how the form is presented in the frontend.
            // For now, keep the original redirect but acknowledge its limitation.
            return RedirectToAction("GaleriaOrcamento", "Home");
        }

        // GET: /Pedido or /Pedido/Index (Admin view)
        public IActionResult Index(string statusFiltro)
        {
            var query = _context.Pedidos
                .Include(p => p.Item) // Eager load Item
                .Include(p => p.ItemVariacao) // Eager load ItemVariacao
                .AsQueryable(); // Start building the query

            // Apply filter based on statusFiltro
            if (!string.IsNullOrEmpty(statusFiltro))
            {
                if (statusFiltro == "validado")
                {
                    query = query.Where(p => p.Validado);
                }
                else if (statusFiltro == "nao_validado")
                {
                    query = query.Where(p => !p.Validado);
                }
                // If statusFiltro is something else or empty, show all (default behavior)
            }

            // Apply sorting (e.g., newest first by ID)
            var pedidos = query.OrderByDescending(p => p.Id).ToList();

            // Prepare options for the filter dropdown
            ViewBag.StatusOptions = new SelectList(new[]
            {
                new { Value = "", Text = "Todos" },
                new { Value = "validado", Text = "Validados" },
                new { Value = "nao_validado", Text = "Não Validados" }
            }, "Value", "Text", statusFiltro); // Pass current filter to select correct option

            return View(pedidos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Add anti-forgery token validation
        public IActionResult Validar(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido != null)
            {
                if (!pedido.Validado) // Only validate if not already validated
                {
                    pedido.Validado = true;
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = $"Pedido #{id} validado com sucesso.";
                }
                else
                {
                    TempData["InfoMessage"] = $"Pedido #{id} já estava validado.";
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Pedido não encontrado.";
            }
            // Redirect back to the index, potentially preserving filters if needed (more complex)
            return RedirectToAction("Index");
        }

        // GET: /Pedido/ExportarPedidosCSV
        public IActionResult ExportarPedidosCSV()
        {
            // 1. Export Pedidos
            var pedidos = _context.Pedidos
                .Include(p => p.Item)
                .Include(p => p.ItemVariacao)
                .OrderByDescending(p => p.Id)
                .ToList();

            var builderPedidos = new StringBuilder();
            builderPedidos.AppendLine("ID,ClienteNome,ClienteTelefone,ClienteEndereco,ItemTitulo,VariacaoNome,Preco,Validado");
            foreach (var pedido in pedidos)
            {
                builderPedidos.AppendLine($"{pedido.Id},{EscapeCsvField(pedido.ClienteNome)},{EscapeCsvField(pedido.ClienteTelefone)},{EscapeCsvField(pedido.ClienteEndereco)},{EscapeCsvField(pedido.Item?.Titulo)},{EscapeCsvField(pedido.ItemVariacao?.Nome)},{pedido.Preco},{pedido.Validado}");
            }
            var pedidosCsvBytes = Encoding.UTF8.GetBytes(builderPedidos.ToString());

            // 2. Export Produtos (Items with Variations and Categories)
            var produtos = _context.items
                .Include(i => i.Categoria)
                .Include(i => i.Variacoes)
                .OrderBy(i => i.Categoria.Nome).ThenBy(i => i.Titulo)
                .ToList();

            var builderProdutos = new StringBuilder();
            builderProdutos.AppendLine("ItemID,ItemTitulo,ItemDescricao,CategoriaNome,VariacaoID,VariacaoNome,VariacaoPreco");
            foreach (var item in produtos)
            {
                if (item.Variacoes != null && item.Variacoes.Any())
                {
                    foreach (var variacao in item.Variacoes)
                    {
                         builderProdutos.AppendLine($"{item.Id},{EscapeCsvField(item.Titulo)},{EscapeCsvField(item.Descricao)},{EscapeCsvField(item.Categoria?.Nome)},{variacao.Id},{EscapeCsvField(variacao.Nome)},{variacao.Preco}");
                    }
                }
                else
                {
                    // Item without variations
                     builderProdutos.AppendLine($"{item.Id},{EscapeCsvField(item.Titulo)},{EscapeCsvField(item.Descricao)},{EscapeCsvField(item.Categoria?.Nome)},,,,");
                }
            }
             var produtosCsvBytes = Encoding.UTF8.GetBytes(builderProdutos.ToString());

            // 3. Export Categorias
            var categorias = _context.ItemCategorias.OrderBy(c => c.Nome).ToList();
            var builderCategorias = new StringBuilder();
            builderCategorias.AppendLine("CategoriaID,CategoriaNome");
            foreach (var categoria in categorias)
            {
                builderCategorias.AppendLine($"{categoria.Id},{EscapeCsvField(categoria.Nome)}");
            }
            var categoriasCsvBytes = Encoding.UTF8.GetBytes(builderCategorias.ToString());

            // Create Zip file in memory
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new System.IO.Compression.ZipArchive(memoryStream, System.IO.Compression.ZipArchiveMode.Create, true))
                {
                    AddEntryToZip(archive, "pedidos.csv", pedidosCsvBytes);
                    AddEntryToZip(archive, "produtos.csv", produtosCsvBytes);
                    AddEntryToZip(archive, "categorias.csv", categoriasCsvBytes);
                }
                // Return the zip file
                return File(memoryStream.ToArray(), "application/zip", "spclima_export.zip");
            }
        }

        // Helper to add byte array as a file entry in ZipArchive
        private void AddEntryToZip(System.IO.Compression.ZipArchive archive, string entryName, byte[] content)
        {
             var entry = archive.CreateEntry(entryName);
             using (var entryStream = entry.Open())
             {
                 entryStream.Write(content, 0, content.Length);
             }
        }

        // Helper function to escape CSV fields (basic implementation)
        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field)) return "";
            // If field contains comma, double quote, or newline, enclose in double quotes and escape existing double quotes
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                return $"\"" + field.Replace("\"", "\"\"") + "\"";
            }
            return field;
        }

        // PDF Export (Placeholder - requires a library like WeasyPrint, iTextSharp, etc.)
        // public IActionResult ExportarPedidosPDF()
        // {
        //     // Implementation using a PDF library
        //     // Fetch data similar to CSV export
        //     // Generate PDF content (HTML template + WeasyPrint or direct generation)
        //     // Return File(...)
        //     TempData["InfoMessage"] = "Exportação para PDF ainda não implementada.";
        //     return RedirectToAction("Index");
        // }
    }
}

