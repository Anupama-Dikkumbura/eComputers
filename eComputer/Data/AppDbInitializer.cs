using System;
using System.Numerics;
using eComputer.Data.Enums;
using eComputer.Data.Static;
using eComputer.Models;
using Microsoft.AspNetCore.Identity;

namespace eComputer.Data
{
	public class AppDbInitializer
	{
		public AppDbInitializer()
		{
		}

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                // Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            CategoryName = "Desktop"
                        },
                        new Category()
                        {
                            CategoryName = "Notebook"
                        },
                    });
                    context.SaveChanges();
                }

                // Series
                if (!context.Serieses.Any())
                {
                    context.Serieses.AddRange(new List<Series>()
                    {
                        new Series()
                        {
                            SeriesName = "Gamer",
                            CategoryId = 1
                            
                        },
                        new Series()
                        {
                            SeriesName = "Personal",
                            CategoryId = 1

                        },
                        new Series()
                        {
                            SeriesName = "Home Premium",
                            CategoryId = 2
                        },
                        new Series()
                        {
                            SeriesName = "Business",
                            CategoryId = 2
                        },
                        new Series()
                        {
                            SeriesName = "Gamer",
                            CategoryId = 2
                        },
                    });
                    context.SaveChanges();
                }

                // Accessories
                if (!context.Accessories.Any())
                {
                    context.Accessories.AddRange(new List<Accessory>()
                    {
                        new Accessory()
                        {
                            AccessoryName = "Intel Core i7",
                            AccessoryType = ItemTypes.Processor,
                            AccessoryDescription = "Brand New processor",
                            AccessoryPrice = 30000.00
                        },
                        new Accessory()
                        {
                            AccessoryName = "Intel Core i3",
                            AccessoryType = ItemTypes.Processor,
                            AccessoryDescription = "Used processor",
                            AccessoryPrice = 10000.00
                        },
                        new Accessory()
                        {
                            AccessoryName = "DDR3 4GB",
                            AccessoryType = ItemTypes.Memory,
                            AccessoryDescription = "Brand New RAM card",
                            AccessoryPrice = 7000.00
                        },
                        new Accessory()
                        {
                            AccessoryName = "Windows 10",
                            AccessoryType = ItemTypes.OS,
                            AccessoryDescription = "With Genuine Licence key",
                            AccessoryPrice = 2000.00
                        },
                        new Accessory()
                        {
                            AccessoryName = "Windows 11",
                            AccessoryType = ItemTypes.OS,
                            AccessoryDescription = "With Genuine Licence key",
                            AccessoryPrice = 3000.00
                        },

                    });
                    context.SaveChanges();
                }
                // Models
                if (!context.ComModels.Any())
                {
                    context.ComModels.AddRange(new List<ComModel>()
                    {
                        new ComModel()
                        {
                            ModelName = "Acer Vivobook",
                            ModelDescription = "vivoboon 3rd generation",
                            ModelPrice = 150000,
                            ImageURL = "https://dlcdnwebimgs.asus.com/gain/eb2c253b-2c02-42e8-90a7-f4bdf31e096d/",
                            CategoryId = 2,
                            SeriesId = 4
                        },
                        

                    });
                    context.SaveChanges();
                }

            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.Sales))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Sales));

                if (!await roleManager.RoleExistsAsync(UserRoles.Manufacture))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Manufacture));

                if (!await roleManager.RoleExistsAsync(UserRoles.Customer))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Customer));


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Admin
                var adminUserEmail = "admin@admin.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Address = "Colombo",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Test@1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                // Sales
                var salesUserEmail = "sales@sales.com";
                var salesUser = await userManager.FindByEmailAsync(salesUserEmail);
                if (salesUser == null)
                {
                    var newSalesUser = new ApplicationUser()
                    {
                        FullName = "Sales User",
                        UserName = "sales-user",
                        Address = "Kandy",
                        Email = salesUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newSalesUser, "Test@1234");
                    await userManager.AddToRoleAsync(newSalesUser, UserRoles.Sales);
                }

                // Manufacture
                var manufactureUserEmail = "manufacture@manufacture.com";
                var manufactureUser = await userManager.FindByEmailAsync(manufactureUserEmail);
                if (manufactureUser == null)
                {
                    var newManufactureUser = new ApplicationUser()
                    {
                        FullName = "Manufacture User",
                        UserName = "manufacture-user",
                        Address = "Matara",
                        Email = manufactureUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newManufactureUser, "Test@1234");
                    await userManager.AddToRoleAsync(newManufactureUser, UserRoles.Manufacture);
                }

                //Customer
                var customerEmail = "customer@customer.com";
                var customer = await userManager.FindByEmailAsync(customerEmail);
                if (customer == null)
                {
                    var newCustomer = new ApplicationUser()
                    {
                        FullName = "Customer",
                        UserName = "customer",
                        Address = "Galle",
                        Email = customerEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newCustomer, "Test@1234");
                    await userManager.AddToRoleAsync(newCustomer, UserRoles.Customer);
                }
            }
        }
    }
}

