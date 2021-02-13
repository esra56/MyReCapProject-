using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        //test
        static void Main(string[] args)
        {
            //CarTest();
            //BrandTest();

            
           CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var addCustomerRes= customerManager.Add(new Customer { UserId = 1, CompanyName = "Company 1" });
            System.Console.WriteLine(addCustomerRes.Message);


            UserManager userManager = new UserManager(new EfUserDal());
            var addUserRes = userManager.Delete(new User {FirstName= "Ayşe", LastName="Kar",Email= "aysekr@gmail.com", Password="2345" });
            System.Console.WriteLine(addUserRes.Message);
        

        //CarManager carManager = new CarManager(new EfCarDal());

        //var result = carManager.GetCarDetails();
        //if (result.Success == true)
        //{

        //    foreach (var car in result.Data)
        //    {
        //        Console.WriteLine(car.CarId + "/" + " " + car.BrandName + " " + car.CarName + " Car color: " + car.ColorName);
        //    }
        //}
        //else
        //{
        //    Console.WriteLine(result.Message);
        //}



        //    CarManager carManager = new CarManager(new EfCarDal());

        //    var result = carManager.GetCarDetails();

        //    if (result.Success==true)
        //    {

        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(Car.CarName + "" + Car.BrandName);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }




        //}

        //private static void BrandTest()
        //{
        //    BrandManager brandManager = new BrandManager(new EfBrandDal());
        //    foreach (var brand in brandManager.GetAll())
        //    {
        //        Console.WriteLine(brand.BrandName);
        //    }
        //}

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());
        //    foreach (var car in carManager.GetCarDetails())
        //    {
        //        Console.WriteLine(car.CarName + "/" + car.BrandName);
        //    }
        //}
    }
    }
}
