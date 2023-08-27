using System.Diagnostics;
using DALInterfaces.Models;
using DALInterfaces.Models.PcBuild;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.PCBuild;
using Microsoft.Extensions.DependencyInjection;

namespace DALEfDB
{
	public class Seed
	{
		public const int MINIMUM_USER_COUNT = 100;

		public void Fill(IServiceProvider services)
		{
			using (var scope = services.CreateScope())
			{
				FillUsers(scope.ServiceProvider);
				FillMovies(scope.ServiceProvider);

				SetFavoriteMovieForAdmin(scope.ServiceProvider);

				FillPcComponents(scope.ServiceProvider);
				FillBuilds(scope.ServiceProvider);
			}
		}

		private void SetFavoriteMovieForAdmin(IServiceProvider serviceProvider)
		{
			var userRepository = serviceProvider.GetService<IUserRepository>();
			var user = userRepository.GetAll().First();
			if (user.FavoriteMovie == null) {
				var movieRepository = serviceProvider.GetService<IMovieRepository>();
				var movie = movieRepository.GetAll().First();
				user.FavoriteMovie = movie;
				userRepository.Update(user);
			}
		}

		private void FillMovies(IServiceProvider serviceProvider)
		{
			var movieRepository = serviceProvider.GetService<IMovieRepository>();
			if (!movieRepository.GetAll().Any())
			{
				for (int i = 0; i < 10; i++)
				{
					var movie1 = new Movie
					{
						Title = $"Die Hard {i}",
						CreatedDate = new DateTime(2020, 12, 13),
					};
					movieRepository.Save(movie1);
				}
			}
		}

		private void FillUsers(IServiceProvider provider)
		{
			var userRepository = provider.GetService<IUserRepository>();
			if (userRepository.Count() <= 0)
			{
				var admin = new User
				{
					Name = "Admin",
					Password = "123",
					Birthday = DateTime.Now,
				};
				userRepository.Save(admin);

				var user = new User
				{
					Name = "User",
					Password = "123",
					Birthday = DateTime.Now,
				};
				userRepository.Save(user);
			}

			if (userRepository.Count() < MINIMUM_USER_COUNT)
			{
				for (int i = 0; i < MINIMUM_USER_COUNT; i++)
				{
					var user = new User
					{
						Name = $"Bot{i}",
						Password = "123",
						Birthday = DateTime.Now,
					};
					userRepository.Save(user);
				}
			}
		}

		private void FillPcComponents(IServiceProvider provider)
		{
			var processorRep = provider.GetService<IProcessorRepository>();
			var motherboardRep = provider.GetService<IMotherboardRepository>();
			var gpuRep = provider.GetService<IGpuRepository>();
			var ramRep = provider.GetService<IRamRepository>();
			var ssdRep = provider.GetService<ISsdRepository>();
			var hddRep = provider.GetService<IHddRepository>();
			var caseRep = provider.GetService<ICaseRepository>();
			var coolerRep = provider.GetService<ICoolerRepository>();
			var psuRep = provider.GetService<IPsuRepository>();

			if (processorRep.Count() <= 0)
			{
				var processor1 = new Processor
				{
					FullName = "Intel Core i5-12400F",
					ProductionDate = new DateTime(2022, 01, 01),
					Price = 525,
					Socket = "LGA1700"
				};
				processorRep.Save(processor1);
				var processor2 = new Processor
				{
					FullName = "AMD Ryzen 5 5600",
					ProductionDate = new DateTime(2022, 01, 01),
					Price = 408,
					Socket = "AM4"
				};
				processorRep.Save(processor2);
			}

			if (motherboardRep.Count() <= 0)
			{
				var motherboard1 = new Motherboard
				{
					FullName = "Gigabyte B550 Aorus Elite AX V2",
					ProductionDate = new DateTime(2022, 01, 01),
					Price = 583,
					Socket = "AM4"
				};
				motherboardRep.Save(motherboard1);
				var motherboard2 = new Motherboard
				{
					FullName = "ASRock Z690 Phantom Gaming 4",
					ProductionDate = new DateTime(2021, 01, 01),
					Price = 475,
					Socket = "LGA1700"
				};
				motherboardRep.Save(motherboard2);
			}
			if (gpuRep.Count() <= 0)
			{
				var gpu1 = new Gpu
				{
					FullName = "GGigabyte GeForce RTX 4080 16GB Aero OC",
					ProductionDate = new DateTime(2022, 01, 01),
					Price = 4689
				};
				gpuRep.Save(gpu1);
				var gpu2 = new Gpu
				{
					FullName = "Gigabyte Radeon RX 6900 XT Gaming OC 16GB GDDR6",
					ProductionDate = new DateTime(2020, 01, 01),
					Price = 2868
				};
				gpuRep.Save(gpu2);
			}
			if (ssdRep.Count() <= 0)
			{
				var ssd1 = new Ssd
				{
					FullName = "SSD ADATA XPG SX6000 Pro 512GB",
					ProductionDate = new DateTime(2018, 01, 01),
					Price = 114
				};
				ssdRep.Save(ssd1);
				var ssd2 = new Ssd
				{
					FullName = "SSD Gigabyte NVMe 256GB",
					ProductionDate = new DateTime(2019, 01, 01),
					Price = 66
				};
				ssdRep.Save(ssd2);
			}
			if (hddRep.Count() <= 0)
			{
				var hdd1 = new Hdd
				{
					FullName = "WD Caviar Blue 1TB",
					ProductionDate = new DateTime(2018, 01, 01),
					Price = 149
				};
				hddRep.Save(hdd1);
				var hdd2 = new Hdd
				{
					FullName = "Toshiba P300 1TB",
					ProductionDate = new DateTime(2019, 01, 01),
					Price = 139
				};
				hddRep.Save(hdd2);
			}
			if (psuRep.Count() <= 0)
			{
				var psu1 = new Psu
				{
					FullName = "Super Flower Leadex V Platinum Pro 850W",
					Power = 850,
					ProductionDate = new DateTime(2019, 01, 01),
					Price = 568
				};
				psuRep.Save(psu1);
				var psu2 = new Psu
				{
					FullName = "DeepCool PK800D",
					Power = 800,
					ProductionDate = new DateTime(2019, 01, 01),
					Price = 139
				};
				psuRep.Save(psu2);
			}
			if (ramRep.Count() <= 0)
			{
				var ram1 = new Ram
				{
					FullName = "G.Skill Ripjaws S5 2x16ГБ DDR5 5600 МГц", 
					ProductionDate = new DateTime(2021, 01, 01),
					Price = 380
				};
				ramRep.Save(ram1);
				var ram2 = new Ram
				{
					FullName = "G.Skill Ripjaws V 2x8GB DDR4 PC4-25600",
					ProductionDate = new DateTime(2019, 01, 01),
					Price = 276
				};
				ramRep.Save(ram2);
			}
			if (caseRep.Count() <= 0)
			{
				var case1 = new Case
				{
					FullName = "Project X Hyperion", 
					ProductionDate = new DateTime(2023, 01, 01),
					Price = 191
				};
				caseRep.Save(case1);
				var case2 = new Case
				{
					FullName = "DeepCool CH510 R-CH510-BKNNE1-G-1",
					ProductionDate = new DateTime(2022, 01, 01),
					Price = 239
				};
				caseRep.Save(case2);
			}
			if (coolerRep.Count() <= 0)
			{
				var cooler1 = new Cooler
				{
					FullName = "ID-Cooling SE-214-XT PRO", 
					ProductionDate = new DateTime(2023, 01, 01),
					Price = 52
				};
				coolerRep.Save(cooler1);
				var cooler2 = new Cooler
				{
					FullName = "DeepCool AK400",
					ProductionDate = new DateTime(2022, 01, 01),
					Price = 102
				};
				coolerRep.Save(cooler2);
			}
		}

		private void FillBuilds(IServiceProvider provider)
		{
			var userRep = provider.GetService<IUserRepository>();
			var processorRep = provider.GetService<IProcessorRepository>();
			var motherboardRep = provider.GetService<IMotherboardRepository>();
			var gpuRep = provider.GetService<IGpuRepository>();
			var ramRep = provider.GetService<IRamRepository>();
			var ssdRep = provider.GetService<ISsdRepository>();
			var hddRep = provider.GetService<IHddRepository>();
			var caseRep = provider.GetService<ICaseRepository>();
			var coolerRep = provider.GetService<ICoolerRepository>();
			var psuRep = provider.GetService<IPsuRepository>();
			var buildRep = provider.GetService<IBuildRepository>();
			if (!buildRep.GetAll().Any())
			{
				var build1 = new Build
				{
					Processor = processorRep.GetAll().First(),
					Motherboard = motherboardRep.GetAll().First(),
					Gpu = gpuRep.GetAll().First(),
					isVirtual = true,
					IsPrivate = false,
					Case = caseRep.GetAll().First(),
					Psu = psuRep.GetAll().First(),
					Ram = ramRep.GetAll().First(),
					Cooler = coolerRep.GetAll().First(), 
					Ssd = ssdRep.GetAll().First(),
					Creator = userRep.GetAll().First(),
					Hdd = hddRep.GetAll().First(),
					Label = "Best build",
					Price = 1234,
					DateOfCreate = DateTime.Now
				};
				buildRep.Save(build1);
			}
		}
	}
}
