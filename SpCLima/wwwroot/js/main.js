/**
* Template Name: Dewi
* Template URL: https://bootstrapmade.com/dewi-free-multi-purpose-html-template/
* Updated: Aug 07 2024 with Bootstrap v5.3.3
* Author: BootstrapMade.com
* License: https://bootstrapmade.com/license/
*/

(function () {
  "use strict";

  /**
   * Apply .scrolled class to the body as the page is scrolled down
   */
  function toggleScrolled() {
    const selectBody = document.querySelector('body');
    const selectHeader = document.querySelector('#header');
    if (!selectHeader.classList.contains('scroll-up-sticky') && !selectHeader.classList.contains('sticky-top') && !selectHeader.classList.contains('fixed-top')) return;
    window.scrollY > 100 ? selectBody.classList.add('scrolled') : selectBody.classList.remove('scrolled');
  }

  document.addEventListener('scroll', toggleScrolled);
  window.addEventListener('load', toggleScrolled);

  /**
   * Mobile nav toggle
   */
  const mobileNavToggleBtn = document.querySelector('.mobile-nav-toggle');

  function mobileNavToogle() {
    document.querySelector('body').classList.toggle('mobile-nav-active');
    mobileNavToggleBtn.classList.toggle('bi-list');
    mobileNavToggleBtn.classList.toggle('bi-x');
  }
  mobileNavToggleBtn.addEventListener('click', mobileNavToogle);

  /**
   * Hide mobile nav on same-page/hash links
   */
  document.querySelectorAll('#navmenu a').forEach(navmenu => {
    navmenu.addEventListener('click', () => {
      if (document.querySelector('.mobile-nav-active')) {
        mobileNavToogle();
      }
    });

  });

  /**
   * Toggle mobile nav dropdowns
   */
  document.querySelectorAll('.navmenu .toggle-dropdown').forEach(navmenu => {
    navmenu.addEventListener('click', function (e) {
      e.preventDefault();
      this.parentNode.classList.toggle('active');
      this.parentNode.nextElementSibling.classList.toggle('dropdown-active');
      e.stopImmediatePropagation();
    });
  });

  /**
   * Preloader
   */
  const preloader = document.querySelector('#preloader');
  if (preloader) {
    window.addEventListener('load', () => {
      preloader.remove();
    });
  }

  /**
   * Scroll top button
   */
  let scrollTop = document.querySelector('.scroll-top');

  function toggleScrollTop() {
    if (scrollTop) {
      window.scrollY > 100 ? scrollTop.classList.add('active') : scrollTop.classList.remove('active');
    }
  }
  scrollTop.addEventListener('click', (e) => {
    e.preventDefault();
    window.scrollTo({
      top: 0,
      behavior: 'smooth'
    });
  });

  window.addEventListener('load', toggleScrollTop);
  document.addEventListener('scroll', toggleScrollTop);

  /**
   * Animation on scroll function and init
   */
  function aosInit() {
    AOS.init({
      duration: 600,
      easing: 'ease-in-out',
      once: true,
      mirror: false
    });
  }
  window.addEventListener('load', aosInit);

  /**
   * Initiate glightbox
   */
  const glightbox = GLightbox({
    selector: '.glightbox'
  });

  /**
   * Initiate Pure Counter
   */
  new PureCounter();

  /**
   * Init swiper sliders
   */
  function initSwiper() {
    document.querySelectorAll(".init-swiper").forEach(function (swiperElement) {
      let config = JSON.parse(
        swiperElement.querySelector(".swiper-config").innerHTML.trim()
      );

      if (swiperElement.classList.contains("swiper-tab")) {
        initSwiperWithCustomPagination(swiperElement, config);
      } else {
        new Swiper(swiperElement, config);
      }
    });
  }

  window.addEventListener("load", initSwiper);

  /**
   * Init isotope layout and filters
   */
  document.querySelectorAll('.isotope-layout').forEach(function (isotopeItem) {
    let layout = isotopeItem.getAttribute('data-layout') ?? 'masonry';
    let filter = isotopeItem.getAttribute('data-default-filter') ?? '*';
    let sort = isotopeItem.getAttribute('data-sort') ?? 'original-order';

    let initIsotope;
    imagesLoaded(isotopeItem.querySelector('.isotope-container'), function () {
      initIsotope = new Isotope(isotopeItem.querySelector('.isotope-container'), {
        itemSelector: '.isotope-item',
        layoutMode: layout,
        filter: filter,
        sortBy: sort
      });
    });

    isotopeItem.querySelectorAll('.isotope-filters li').forEach(function (filters) {
      filters.addEventListener('click', function () {
        isotopeItem.querySelector('.isotope-filters .filter-active').classList.remove('filter-active');
        this.classList.add('filter-active');
        initIsotope.arrange({
          filter: this.getAttribute('data-filter')
        });
        if (typeof aosInit === 'function') {
          aosInit();
        }
      }, false);
    });

  });

  /**
   * Correct scrolling position upon page load for URLs containing hash links.
   */
  window.addEventListener('load', function (e) {
    if (window.location.hash) {
      if (document.querySelector(window.location.hash)) {
        setTimeout(() => {
          let section = document.querySelector(window.location.hash);
          let scrollMarginTop = getComputedStyle(section).scrollMarginTop;
          window.scrollTo({
            top: section.offsetTop - parseInt(scrollMarginTop),
            behavior: 'smooth'
          });
        }, 100);
      }
    }
  });

  /**
   * Navmenu Scrollspy
   */
  let navmenulinks = document.querySelectorAll('.navmenu a');

  function navmenuScrollspy() {
    navmenulinks.forEach(navmenulink => {
      if (!navmenulink.hash) return;
      let section = document.querySelector(navmenulink.hash);
      if (!section) return;
      let position = window.scrollY + 200;
      if (position >= section.offsetTop && position <= (section.offsetTop + section.offsetHeight)) {
        document.querySelectorAll('.navmenu a.active').forEach(link => link.classList.remove('active'));
        navmenulink.classList.add('active');
      } else {
        navmenulink.classList.remove('active');
      }
    })
  }
  window.addEventListener('load', navmenuScrollspy);
  document.addEventListener('scroll', navmenuScrollspy);

})();

// Get the modal
var modal = document.getElementById("calcularBtusModal");

// Get the button that opens the modal
var btn = document.getElementById("calcularBtusBtn");

// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];

// When the user clicks the button, open the modal
btn.onclick = function () {
  modal.style.display = "block";
}

// When the user clicks on <span> (x), close the modal
span.onclick = function () {
  modal.style.display = "none";
}

// When the user clicks anywhere outside of the modal, close it
window.onclick = function (event) {
  if (event.target == modal) {
    modal.style.display = "none";
  }
}

// Function to calculate BTUs
function calcularBTUs() {
  // Get values from the form
  var largura = parseFloat(document.getElementById("largura").value);
  var comprimento = parseFloat(document.getElementById("comprimento").value);
  var altura = parseFloat(document.getElementById("altura").value);

  // Validate if the user has entered valid numbers
  if (isNaN(largura) || isNaN(comprimento) || isNaN(altura) || largura <= 0 || comprimento <= 0 || altura <= 0) {
    alert("Por favor, insira valores válidos.");
    return;
  }

  // Calculate the area (largura * comprimento)
  var area = largura * comprimento;

  // Calculate the required BTUs (using a basic formula)
  var btus = area * 600; // Simple approximation for residential areas

  // Display the result
  document.getElementById("resultadoTexto").textContent = "O seu ambiente precisa de aproximadamente " + btus + " BTUs.";
  document.getElementById("resultadoBTUs").style.display = "block"; // Show the result section
}

// Attach the calculation function to the form submit event
document.getElementById("btusForm").onsubmit = function (event) {
  event.preventDefault(); // Prevent form submission and page reload
  calcularBTUs(); // Call the function to calculate BTUs
};


const carrinho = [];

function abrirCarrinho() {
  document.getElementById("carrinho").classList.add("aberto");
  renderizarCarrinho();
}

function fecharCarrinho() {
  document.getElementById("carrinho").classList.remove("aberto");
}

function adicionarAoCarrinho(nome, imagem, preco, descricao, categoria) {
  carrinho.push({ nome, imagem, preco, descricao, categoria, tipoServico: "", detalhes: {} });
  abrirCarrinho();
  renderizarCarrinho();
}

function removerDoCarrinho(index) {
  carrinho.splice(index, 1);
  renderizarCarrinho();
}

function renderizarCarrinho() {
  const container = document.getElementById("itensCarrinho");
  container.innerHTML = "";

  carrinho.forEach((item, index) => {
    const card = document.createElement("div");
    card.className = "col-12";

    let tiposServicos = "";
    if (item.categoria === "instalacao") {
      tiposServicos = `
                    <label class="form-label mt-2">Tipo de Instalação:</label>
                    <select class="form-select mb-2" onchange="handleTipoServico(this.value, ${index})">
                        <option value="">Selecione</option>
                        <option value="ar">Ar-condicionado</option>
                        <option value="cortina">Cortina de Ar</option>
                        <option value="bebedouro">Bebedouro</option>
                        <option value="refrigerador">Refrigerador</option>
                        <option value="maquina">Máquina de Lavar</option>
                        <option value="outro">Outro</option>
                    </select>
                `;
    } else if (item.categoria === "manutencao") {
      tiposServicos = `
                    <label class="form-label mt-2">Equipamento:</label>
                    <select class="form-select mb-2" onchange="handleTipoServico(this.value, ${index})">
                        <option value="">Selecione</option>
                        <option value="ar">Ar-condicionado</option>
                        <option value="cortina">Cortina de Ar</option>
                        <option value="bebedouro">Bebedouro</option>
                        <option value="refrigerador">Refrigerador</option>
                        <option value="maquina">Máquina de Lavar</option>
                    </select>
                `;
    } else if (item.categoria === "limpeza") {
      tiposServicos = `
                    <label class="form-label mt-2">Tipo de Limpeza:</label>
                    <select class="form-select mb-2" onchange="handleTipoServico(this.value, ${index})">
                        <option value="">Selecione</option>
                        <option value="ar">Ar-condicionado</option>
                        <option value="maquina">Máquina de Lavar</option>
                    </select>
                `;
    }

    let camposExtras = "";
    if (item.tipoServico === "ar") {
      camposExtras = `
                    <label class="form-label">BTUs:</label>
                    <select class="form-select mb-2" onchange="atualizarDetalhes(${index}, 'BTUs', this.value)">
                        <option>9000</option>
                        <option>12000</option>
                        <option>14000</option>
                        <option>16000</option>
                        <option>Outro</option>
                    </select>
                `;
    } else if (item.tipoServico === "cortina") {
      camposExtras = `
                    <label class="form-label">Medidas:</label>
                    <select class="form-select mb-2" onchange="atualizarDetalhes(${index}, 'Medida', this.value)">
                        <option>90-150 cm</option>
                        <option>180-200 cm</option>
                        <option>250 cm</option>
                    </select>
                    <label class="form-label">Marca:</label>
                    <input type="text" class="form-control mb-2" placeholder="Ex: Elgin" onchange="atualizarDetalhes(${index}, 'Marca', this.value)">
                `;
    } else if (item.tipoServico === "maquina") {
      camposExtras = `
                    <label class="form-label">Tamanho:</label>
                    <select class="form-select mb-2" onchange="atualizarDetalhes(${index}, 'Capacidade', this.value)">
                        <option>Pequena (8-9 KG)</option>
                        <option>Média (10-12 KG)</option>
                        <option>Grande (13-16 KG)</option>
                        <option>Extra Grande (17-20 KG)</option>
                    </select>
                `;
    } else if (item.tipoServico === "refrigerador") {
      camposExtras = `
                    <label class="form-label">Tipo:</label>
                    <select class="form-select mb-2" onchange="atualizarDetalhes(${index}, 'Tipo Refrigerador', this.value)">
                        <option>Geladeira 1 Porta</option>
                        <option>Geladeira Duplex</option>
                        <option>Geladeira Side by Side</option>
                        <option>Freezer (100-300 L)</option>
                        <option>Freezer (400-600 L)</option>
                    </select>
                `;
    } else if (item.tipoServico === "bebedouro") {
      camposExtras = `
                    <label class="form-label">Capacidade:</label>
                    <select class="form-select mb-2" onchange="atualizarDetalhes(${index}, 'Litros', this.value)">
                        <option>Bebedouro (5–10 L)</option>
                        <option>Bebedouro (20–30 L)</option>
                        <option>Bebedouro (50+ L)</option>
                    </select>
                `;
    }

    card.innerHTML = `
                <div class="card shadow-sm border mb-3">
                    <div class="row g-0">
                        <div class="col-4">
                            <img src="${item.imagem}" class="img-fluid rounded-start" alt="${item.nome}">
                        </div>
                        <div class="col-8">
                            <div class="card-body p-2">
                                <h6 class="card-title mb-1">${item.nome}</h6>
                                <p class="card-text text-muted mb-1"><small>${item.descricao}</small></p>
                                <p class="card-text"><strong>${item.preco}</strong></p>
                                ${tiposServicos}
                                ${camposExtras}
                                <button class="btn btn-sm btn-outline-danger mt-2" onclick="removerDoCarrinho(${index})">
                                    <i class="bi bi-trash"></i> Remover
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            `;

    container.appendChild(card);
  });

  // Adiciona botão de finalização
  if (carrinho.length > 0) {
    container.innerHTML += `
                <div class="text-end mt-3">
                    <button class="btn btn-success" onclick="finalizarOrcamento()">Finalizar Orçamento</button>
                </div>
            `;
  }
};

function handleTipoServico(valor, index) {
  carrinho[index].tipoServico = valor;
  carrinho[index].detalhes = {};
  renderizarCarrinho();
}

function atualizarDetalhes(index, campo, valor) {
  carrinho[index].detalhes[campo] = valor;
}

function finalizarOrcamento() {
  const numeroWhatsApp = "5511999999999"; // <- Altere para o número da empresa
  let mensagem = "Olá, gostaria de solicitar um orçamento com os seguintes itens:\n\n";

  carrinho.forEach((item, i) => {
    mensagem += `🔹 *${item.nome}* - ${item.preco}\n`;
    mensagem += `📄 ${item.descricao}\n`;
    if (item.tipoServico) mensagem += `🛠 Tipo: ${item.tipoServico}\n`;
    for (const [chave, valor] of Object.entries(item.detalhes)) {
      mensagem += `▪️ ${chave}: ${valor}\n`;
    }
    mensagem += `\n`;
  });

  const url = `https://wa.me/${numeroWhatsApp}?text=${encodeURIComponent(mensagem)}`;
  window.open(url, "_blank");
};





