using Microsoft.AspNetCore.Mvc;
using AlgorithmSite.Models;
using AlgorithmSite.Services;
using AlgorithmSite.Business;

namespace AlgorithmSite.Controllers
{
    [ApiController]
    [Route("api/sorts")]
    public class APIController : Controller
    {

        private readonly AnalysesService _analysesService;
        private readonly SortAnalyzer _sortAnalyzer;

        public APIController(AnalysesService analysesService, SortAnalyzer sortAnalyzer)
        {
            _analysesService = analysesService;
            _sortAnalyzer = sortAnalyzer;
        } 

        [HttpGet]
        public async Task<List<AnalysisObjDBModel>> Get() =>
            await _analysesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<AnalysisObjDBModel>> Get(string id)
        {
            var sortsObj = await _analysesService.GetAsync(id);
            return sortsObj is null ? NotFound() : sortsObj;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnalysisObjDBModel newSorts)
        {
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, AnalysisObjDBModel updatedSorts)
        {
            var sorts = await _analysesService.GetAsync(id);
            if(sorts is null)
            {
                return NotFound();
            }

            updatedSorts.Id = sorts.Id;

            await _analysesService.UpdateAsync(id, updatedSorts);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var sorts = await _analysesService.GetAsync(id);
            if(sorts is null)
            {
                return NotFound();
            }

            await _analysesService.RemoveAsync(sorts.Id);
            return NoContent();
        }

        [HttpGet]
        [Route("createdefault")]
        public async Task<IActionResult> Post()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultWordBubbleAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
