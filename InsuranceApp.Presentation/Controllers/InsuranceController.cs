using AutoMapper;
using InsuranceApp.Application.DTOs;
using InsuranceApp.Application.Interfaces;
using InsuranceApp.Domain.Entities.Enums;
using InsuranceApp.Presentation.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InsuranceApp.Presentation.Controllers
{
    public class InsuranceController : Controller
    {
        private readonly IInsuranceManager _manager;
        private readonly IMapper _mapper;

        public InsuranceController(IInsuranceManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var insurances = await _manager.GetAllAsync();
            return View(insurances);
        }

        public async Task<IActionResult> Details(int id)
        {
            var insurance = await _manager.GetByIdAsync(id);
            if (insurance == null)
                return NotFound();

            return View(insurance);
        }

        public IActionResult Create(int insuredPersonId)
        {
            var viewModel = new InsuranceFormViewModel
            {
                InsuredPersonId = insuredPersonId,
                ValidFrom = DateTime.Today,
                ValidTo = DateTime.Today.AddYears(1),
                InsuranceTypeOptions = GetInsuranceTypeOptions()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsuranceFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // Reload enum after validation fail
                viewModel.InsuranceTypeOptions = GetInsuranceTypeOptions();
                return View(viewModel);
            }

            var dto = _mapper.Map<InsuranceDto>(viewModel);
            await _manager.CreateAsync(dto);
            return RedirectToAction("Details", "InsuredPerson", new { id = viewModel.InsuredPersonId });
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _manager.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            var viewModel = _mapper.Map<InsuranceFormViewModel>(dto);
            viewModel.InsuranceTypeOptions = GetInsuranceTypeOptions();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InsuranceFormViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                // Reload enum after validation fail
                viewModel.InsuranceTypeOptions = GetInsuranceTypeOptions();
                return View(viewModel);
            }

            var dto = _mapper.Map<InsuranceDto>(viewModel);
            await _manager.UpdateAsync(dto);
            return RedirectToAction("Details", "InsuredPerson", new { id = viewModel.InsuredPersonId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var dto = await _manager.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            return View(dto);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dto = await _manager.GetByIdAsync(id);
            if (dto != null)
                await _manager.DeleteAsync(id);

            return RedirectToAction("Details", "InsuredPerson", new { id = dto?.InsuredPersonId });
        }

        private static IEnumerable<SelectListItem> GetInsuranceTypeOptions()
        {
            // Convert enum values to SelectListItem
            return Enum.GetValues(typeof(InsuranceType))
                .Cast<InsuranceType>()
                .Select(t => new SelectListItem
                {
                    Value = t.ToString(),
                    Text = t.ToString()
                });
        }

    }
}
