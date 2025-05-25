using AutoMapper;
using InsuranceApp.Application.DTOs;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Presentation.Controllers
{
    public class InsuredPersonController : Controller
    {
        private readonly IInsuredPersonManager _manager;
        private readonly IMapper _mapper;

        public InsuredPersonController(IInsuredPersonManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _manager.GetAllAsync();
            return View(items);
        }

        public async Task<IActionResult> Details(int id)
        {
            var person = await _manager.GetWithInsurancesAsync(id);
            if (person == null)
                return NotFound();

            return View(person);
        }

        public IActionResult Create()
        {
            return View(new InsuredPersonFormViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InsuredPersonFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var dto = _mapper.Map<InsuredPersonDto>(viewModel);
            await _manager.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _manager.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            var viewModel = _mapper.Map<InsuredPersonFormViewModel>(dto);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InsuredPersonFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var dto = _mapper.Map<InsuredPersonDto>(viewModel);
            await _manager.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _manager.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _manager.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
