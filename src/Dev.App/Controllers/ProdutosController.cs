using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dev.App.Data;
using Dev.App.ViewModels;
using Dev.Business.Interfaces;
using AutoMapper;
using AppMvcBasica.Models;

namespace Dev.App.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository,
            IMapper mapper,
            IFornecedorRepository fornecedorRepository)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
            _fornecedorRepository = fornecedorRepository;
        }


        public async Task<IActionResult> Index()
        {
            var produto = _mapper.Map<IEnumerable<ProdutoViewModel>>(await _produtoRepository.GetProdutosFornecedores());
            return View(produto);
        }


        public async Task<IActionResult> Details(Guid id)
        {

            var produtoViewModel = await GetProduto(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }


        public async Task<IActionResult> Create()
        {
            var produtoViewModel = await PopulateFornecedores(new ProdutoViewModel());
            return View(produtoViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProdutoViewModel produtoViewModel)
        {
            produtoViewModel = await PopulateFornecedores(new ProdutoViewModel());

            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoRepository.Add(_mapper.Map<Produto>(produtoViewModel));
            
            return View(produtoViewModel);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            var produto = await GetProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(produtoViewModel);

            await _produtoRepository.Update(_mapper.Map<Produto>(produtoViewModel));

            return RedirectToAction("Index");
            
        }


        public async Task<IActionResult> Delete(Guid id)
        {
            var produto = await GetProduto(id);
                
            if (produto == null) return NotFound();

            return View(produto);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var produto = await GetProduto(id);

            if (produto == null) return NotFound();

            await _produtoRepository.Delete(id);

            return RedirectToAction("Index");
        }

        private async Task<ProdutoViewModel> GetProduto(Guid id)
        {
            var produto = _mapper.Map<ProdutoViewModel>(await _produtoRepository.GetProdutoFornecedor(id));

            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.GetAll());

            return produto;
        }

        private async Task<ProdutoViewModel> PopulateFornecedores(ProdutoViewModel produto)
        {
            produto.Fornecedores = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.GetAll());

            return produto;
        }
    }
}
