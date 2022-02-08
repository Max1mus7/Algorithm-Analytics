using AlgorithmSite.APISorting.SortAnalytics;
using AlgorithmSite.Business;
using AlgorithmSite.Models;
using AlgorithmSite.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AlgorithmSite.Controllers
{
    //Controller allowing connection to API
    [ApiController]
    //Controls the routing
    [Route("api")]
    public class APIController : Controller
    {
        //defines a singleton for each service class
        private readonly AnalysesService _analysesService;
        private readonly SortAnalyzer _sortAnalyzer;

        //upon construction, populates singletons
        public APIController(AnalysesService analysesService, SortAnalyzer sortAnalyzer)
        {
            _analysesService = analysesService;
            _sortAnalyzer = sortAnalyzer;
        }

        [HttpGet]
        public IActionResult Sorts()
        {
            return View();
        }

        //Gets a list of all data within the DB
        [HttpGet("sorts")]
        public async Task<List<AnalysisObjDBModel>> Get() =>
            await _analysesService.GetAsync();

        //Gets a specific sort analysis from the database
        [HttpGet("sorts/{id:length(24)}")]
        public async Task<ActionResult<AnalysisObjDBModel>> Get(string id)
        {
            var sortsObj = await _analysesService.GetAsync(id);
            return sortsObj is null ? NotFound() : sortsObj;
        }


        [HttpPost("sorts")]
        public async Task<IActionResult> Post(AnalysisObjDBModel newSorts)
        {
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        [HttpPut("sorts/{id:length(24)}")]
        public async Task<IActionResult> Update(string id, AnalysisObjDBModel updatedSorts)
        {
            var sorts = await _analysesService.GetAsync(id);
            if (sorts is null)
            {
                return NotFound();
            }

            updatedSorts.Id = sorts.Id;

            await _analysesService.UpdateAsync(id, updatedSorts);
            return NoContent();
        }

        //=========================================================================================================
        //Deletion
        //Deletes with an HTTP DELETE request
        [HttpDelete("sorts/{id:length(24)}")]
        public async Task<IActionResult> HttpDelete(string id)
        {
            var sorts = await _analysesService.GetAsync(id);
            if (sorts is null)
            {
                return NotFound();
            }

            await _analysesService.RemoveAsync(sorts.Id);
            return NoContent();
        }

        //Deletes with an HTTP GET request
        [HttpGet("sorts/delete/{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var sorts = await _analysesService.GetAsync(id);
            if (sorts is null)
            {
                return NotFound();
            }
            await _analysesService.RemoveAsync(sorts.Id);
            return NoContent();
        }

        //=========================================================================================================
        //Creation
        //===========================================
        //Default Data Creation

        //creates a default bubble sort analysis on words and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/bubble/word")]
        public async Task<IActionResult> BubbleSortWordDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultWordBubbleAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }
        //creates a default bubble sort analysis on numbers and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/bubble/number")]
        public async Task<IActionResult> BubbleSortNumDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultNumBubbleAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        //creates a default insertion sort analysis on words and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/insertion/word")]
        public async Task<IActionResult> InsertionSortWordDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultWordInsertionAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        //creates a default insertion sort analysis on numbers and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/insertion/number")]
        public async Task<IActionResult> InsertionSortNumDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultNumInsertionAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        //creates a default selection sort analysis on words and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/selection/word")]
        public async Task<IActionResult> SelectionSortWordDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultWordSelectionAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        //creates a default selection sort analysis on numbers and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/selection/number")]
        public async Task<IActionResult> SelectionSortNumDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultNumSelectionAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }
        //creates a default quicksort analysis on numbers and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/quicksort/number")]
        public async Task<IActionResult> QuicksortNumDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultNumQuicksortAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }
        //creates a default quicksort analysis on words and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/quicksort/word")]
        public async Task<IActionResult> QuicksortWordDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultWordQuicksortAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }

        //creates a default merge sort analysis on numbers and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/merge/number")]
        public async Task<IActionResult> MergeSortNumDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultNumMergeAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }
        //creates a default quicksort analysis on words and adds it to the database
        [HttpGet]
        [Route("sorts/createdefault/merge/word")]
        public async Task<IActionResult> MergeWordDefault()
        {
            AnalysisObjDBModel newSorts = new AnalysisObjDBModel(await _sortAnalyzer.GetDefaultWordMergeAnalysis());
            await _analysesService.CreateAsync(newSorts);
            return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
        }



        //Default Data Creation
        //===========================================
        //Custom Data Creation

        //create a custom record given the information required for a sort in the request body as JSON
        [HttpPost("sorts/createcustom")]
        public async Task<IActionResult> PostCustom()
        {
            //read the request body
            using (StreamReader sr = new StreamReader(Request.Body, Encoding.UTF8))
            {
                try
                {
                    //get the string version of the body(should be JSON)
                    string newSortsJSON = await sr.ReadToEndAsync();
                    AnalysisObjDBModel newSorts = new AnalysisObjDBModel(JsonConvert.DeserializeObject<AnalysisObj>(newSortsJSON));
                    await _analysesService.CreateAsync(newSorts);
                    return CreatedAtAction(nameof(Get), new { id = newSorts.Id }, newSorts);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
        }


        //Custom Data Creation
        //===========================================
        //Creation
        //=========================================================================================================

        public IActionResult Index()
        {
            return View();
        }
    }
}
