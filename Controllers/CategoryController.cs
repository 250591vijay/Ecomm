using Ecomm.Data;
using Ecomm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//Using
//This is controller class
namespace Ecomm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ApplicationDbContext _context;

        // Constructor to access data from database
        public CategoryController(ApplicationDbContext context)
        {
            this._context = context;
        }

        // GET :api/<CategoryController> get all data from data base
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Categories.ToListAsync());
            // Return OK means sucessfully get result
            // retutn NotFound();
            // return BadRequest();
        }
        // GET :api/<CategoryController>5 to get particular id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            //var data = _context.Categories;
            return Ok(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        // POST :api/<CategoryController> Save
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
            //return Ok();
        }

        // PUT :api/<CategoryController> Update
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var categoryFromDb = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            // For Exception handling we use if condtion
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            else
            {
                // To update the value 
                // categories wale table s jo data aayega wo categoryFromDb m aayega 
                categoryFromDb.Title = category.Title;
                categoryFromDb.DisplayOrder = category.DisplayOrder;
                _context.Categories.Update(categoryFromDb);
                await _context.SaveChangesAsync();
                return Ok("Category Updated");
                //return StatusCode(StatusCodes.Status201Created);
            }
        }
        // DELETE :api/<CategoryController> 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] Category category, int id)
        {
            var categoryFromDb = await _context.Categories.FindAsync(id);
            // For Exception handling
            if (categoryFromDb == null)
            {
                return NotFound();
            } else
            {
            _context.Categories.Remove(categoryFromDb);
            await _context.SaveChangesAsync();
            return Ok("Category Deleted");
            }
        }

    }
}

















// is code m Async and Task<T> use nhi huwa

//public class CategoryController : ControllerBase
//{
//    private ApplicationDbContext _context;

//    // Constructor to access data from database
//    public CategoryController(ApplicationDbContext context)
//    {
//        this._context = context;
//    }

//    // GET :api/<CategoryController> get all data from data base
//    [HttpGet]
//    public IActionResult Get()
//    {
//        return Ok(_context.Categories);
//        // Return OK means sucessfully get result
//        // retutn NotFound();
//        // return BadRequest();
//    }
//    // GET :api/<CategoryController>5 to get particular id
//    [HttpGet("{id}")]
//    public IActionResult Get(int id)
//    {
//        //var data = _context.Categories;
//        return Ok(_context.Categories.FirstOrDefault(x => x.Id == id));
//    }

//    // POST :api/<CategoryController> Save
//    [HttpPost]
//    public IActionResult Post([FromBody] Category category)
//    {
//        _context.Categories.Add(category);
//        _context.SaveChanges();
//        return StatusCode(StatusCodes.Status201Created);
//        //return Ok();
//    }

//    // PUT :api/<CategoryController> Update
//    [HttpPut("{id}")]
//    public IActionResult Put(int id, [FromBody] Category category)
//    {
//        var categoryFromDb = _context.Categories.FirstOrDefault(x => x.Id == id);
//        // For Exception handling
//        if (categoryFromDb == null)
//        {
//            return NotFound();
//        }
//        else
//        {
//            // To update the value 
//            // categories wale table s jo data aayega wo categoryFromDb m aayega 
//            categoryFromDb.Title = category.Title;
//            categoryFromDb.DisplayOrder = category.DisplayOrder;
//            _context.Categories.Update(categoryFromDb);
//            _context.SaveChanges();
//            return Ok("Category Updated");
//            //return StatusCode(StatusCodes.Status201Created);
//        }
//    }
//    // DELETE :api/<CategoryController> 
//    [HttpDelete("{id}")]
//    public IActionResult Delete([FromBody] Category category, int id)
//    {
//        var categoryFromDb = _context.Categories.Find(id);
//        // For Exception handling
//        if (categoryFromDb == null)
//        {
//            return NotFound();
//        }
//        else
//        {
//            _context.Categories.Remove(categoryFromDb);
//            _context.SaveChanges();
//            return Ok("Category Deleted");
//        }
//    }

//}





// Ye jo controller hai is m IActionResult  nhi use huwa hai
// IActionResult hum log status code check karne k liye use karte hai

//public class CategoryController : ControllerBase
//{
//    private ApplicationDbContext _context;

//    Constructor to access data from database
//    public CategoryController(ApplicationDbContext context)
//    {
//        this._context = context;
//    }

//    GET :api/<CategoryController> get all data from data base
//    [HttpGet]
//    public IEnumerable<Category> Get()
//    {
//        return _context.Categories;
//    }
//    GET :api/<CategoryController>5 to get particular id
//   [HttpGet("{id}")]
//    public Category Get(int id)
//    {
//        var data = _context.Categories;
//        return _context.Categories.FirstOrDefault(x => x.Id == id);
//    }
//    POST :api/<CategoryController> Save
//   [HttpPost]
//    public void Post([FromBody] Category category)
//    {
//        _context.Categories.Add(category);
//        _context.SaveChanges();
//    }
//    PUT :api/<CategoryController> Update
//   [HttpPut]
//    public void Put([FromBody] Category category, int id)
//    {
//        var categoryFromDb = _context.Categories.FirstOrDefault(x => x.Id == id);
//        To update the value
//         categories wale table s jo data aayega wo categoryFromDb m aayega
//        categoryFromDb.Title = category.Title;
//        categoryFromDb.DisplayOrder = category.DisplayOrder;
//        _context.Categories.Update(categoryFromDb);
//        _context.SaveChanges();
//    }
//    DELETE :api/<CategoryController> 
//    [HttpDelete]
//    public void Delete([FromBody] Category category, int id)
//    {
//        var categoryFromDb = _context.Categories.Find(id);
//        _context.Categories.Remove(categoryFromDb);
//        _context.SaveChanges();
//    }

//}














// Ye controller mock data k sath hai


//using Ecomm.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace Ecomm.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CategoryController : ControllerBase
//    {
//        // class ko static baney hai kyu is class ko baar baar use karna hai
//        // static nhi lagaenge to data add nhi hoga
//        public static List<Category> listofCateogries = new List<Category>
//        {
//            new Category{Id=1,Title="Samsung",DisplayOrder="1"},
//            new Category{Id=2,Title="Nokia",DisplayOrder= "2"},
//            new Category{Id=3,Title="LG",DisplayOrder= "3"},
//            new Category{Id=4,Title="Xiomi",DisplayOrder= "4"},
//            new Category{Id=5,Title="Apple",DisplayOrder= "5"},

//        };
//        [HttpGet]
//        public IEnumerable<Category> Get()
//        {
//            return listofCateogries;
//        }
//        [HttpPost]
//        public void Post([FromBody] Category category)
//        {
//            listofCateogries.Add(category);
//        }
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] Category category)
//        {
//            // id jo url s jaeyga
//            listofCateogries[id] = category;
//        }
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//            // id jo url s jaeyga
//            listofCateogries.RemoveAt(id);
//        }
//    }
//}