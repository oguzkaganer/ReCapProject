using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WepAPI.Controllers
{
	public class CarImagesController : Controller
	{
		ICarImageService _carImageService;

		public CarImagesController(ICarImageService carImageService)
		{
			_carImageService = carImageService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _carImageService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbycarid")]
		public IActionResult GetByCarId(int id)
		{
			var result = _carImageService.GetByCarId(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(CarImage carImage, IFormFile formFile)
		{
			var result = _carImageService.Add(carImage, formFile);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPut("update")]
		public IActionResult Update(CarImage carImage, IFormFile formFile)
		{
			var result = _carImageService.Update(carImage, formFile);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpDelete("delete")]
		public IActionResult Delete(CarImage carImage)
		{
			var result = _carImageService.Delete(carImage);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
