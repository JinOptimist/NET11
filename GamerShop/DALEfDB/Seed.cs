using System.Diagnostics;
using DALInterfaces.Models;
using DALInterfaces.Models.PcBuild;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.PCBuild;
using DALInterfaces.Repositories.Movies;
using Microsoft.Extensions.DependencyInjection;
using System;
using DALInterfaces.Repositories.Recipe;
using DALEfDB.Repositories;
using DALInterfaces.Models.Recipe;
using Microsoft.Identity.Client;
using DALEfDB.Repositories.Recipe;
using DALInterfaces.Repositories.Football;
using System.Dynamic;
using DALInterfaces.Models.BG;
using GamerShop.Services.Football;
using DALInterfaces.Models.RockHall;
using DALInterfaces.Repositories.BG;
using DALInterfaces.Repositories.RockHall;

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
                FillRecipes(scope.ServiceProvider);

                FillPcComponents(scope.ServiceProvider);
                FillBuilds(scope.ServiceProvider);
                FillHeroAtribute(scope.ServiceProvider);
                FillGenres(scope.ServiceProvider);
                FillMovies(scope.ServiceProvider);
                FillCollections(scope.ServiceProvider);
                FillFootbal(scope.ServiceProvider);
                FillRockMembers(scope.ServiceProvider);
                FillRockBands(scope.ServiceProvider);
            }
        }

        private void FillRecipes(IServiceProvider serviceProvider)
        {
            Random random = new Random();
            var recipeRepository = serviceProvider.GetService<IRecipeRepository>();
            var userRepository = serviceProvider.GetService<IUserRepository>();
            var reviewRepository = serviceProvider.GetService<IReviewRepository>();
            if (recipeRepository.Count() <= 5)
            {
                for (int i = 0; i < 10; i++)
                {
                    var recipe = new Recipe
                    {
                        Title = "Recipe" + i,
                        CookingTime = random.Next(0, 100),
                        PreparationTime = random.Next(0, 60),
                        Servings = random.Next(1, 6),
                        CreatedByUserId = userRepository.GetAll().First().Id,
                        CreatedOn = DateTime.Now,
                        Cuisine = "Cuisine" + i,
                        Description = "Description" + i,
                        DifficultyLevel = random.Next(1, 5).ToString(),
                        Instructions = "Instructions" + i,
                    };
                    recipeRepository.Save(recipe);
                    for (int j = 0; j < random.Next(0, 5); j++)
                    {
                        var review = new Review()
                        {
                            Recipe = recipeRepository.GetAll().Last(),
                            User = userRepository.GetAll().First(),
                            Rating = random.Next(1, 5),
                            ReviewText = "Review text" + j,
                            ReviewDate = DateTime.Now
                        };

                        reviewRepository.Save(review);
                    }
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

        private void FillHeroAtribute(IServiceProvider provider)
        {
            var userRepository = provider.GetService<IUserRepository>();
            var classRep = provider.GetService<IClassRepository>();
            var raceRep = provider.GetService<IRaceRepository>();
            var subraceRep = provider.GetService<ISubraceRepository>();
            var originRep = provider.GetService<IOriginRepository>();
            var heroRep =provider.GetService<IHeroRepository>();

            if (classRep.Count() <= 0)
            {
                var class1 = new Class
                {
                    Name = "Варвар"
                };
                classRep.Save(class1);

                var class2 = new Class
                {
                    Name = "Бард "
                };
                classRep.Save(class2);

                var class3 = new Class
                {
                    Name = "Жрец"
                };
                classRep.Save(class3);

                var class4 = new Class
                {
                    Name = "Друид "
                };
                classRep.Save(class4);

                var class5 = new Class
                {
                    Name = "Воин"
                };
                classRep.Save(class5);

                var class6 = new Class
                {
                    Name = "Монах"
                };
                classRep.Save(class6);

                var class7 = new Class
                {
                    Name = "Паладин"
                };
                classRep.Save(class7);

                var class8 = new Class
                {
                    Name = "Следопыт"
                };
                classRep.Save(class8);

                var class9 = new Class
                {
                    Name = "Плут"
                };
                classRep.Save(class9);

                var class10 = new Class
                {
                    Name = "Чародей"
                };
                classRep.Save(class10);

                var class11 = new Class
                {
                    Name = "Колдун"
                };
                classRep.Save(class11);

                var class12 = new Class
                {
                    Name = "Волшебник"
                };
                classRep.Save(class12);

            }

            if (raceRep.Count() <= 5)
            {
                var race1 = new Race
                {
                    Name = "Тифлинг"
                };
                raceRep.Save(race1);

                var race2 = new Race
                {
                    Name = "Эльф"
                };
                raceRep.Save(race2);

                var race3 = new Race
                {
                    Name = "Человек"
                };
                raceRep.Save(race3);

                var race4 = new Race
                {
                    Name = "Гитьян"
                };
                raceRep.Save(race4);

                var race5 = new Race
                {
                    Name = "Дроу"
                };
                raceRep.Save(race5);

                var race6 = new Race
                {
                    Name = "Халфинг"
                };
                raceRep.Save(race6);

                var race7 = new Race
                {
                    Name = "Полуэльф"
                };
                raceRep.Save(race7);

                var race8 = new Race
                {
                    Name = "Дварф"
                };
                raceRep.Save(race8);

                var race9 = new Race
                {
                    Name = "Драконорожденный"
                };
                raceRep.Save(race9);

                var race10 = new Race
                {
                    Name = "Полуорк"
                };
                raceRep.Save(race10);

            }

            if (subraceRep.Count() <= 0)
            {
                var subrace1 = new Subrace
                {
                    Name = "Асмодей",
                    Race = raceRep.Get(1002)

                };
                subraceRep.Save(subrace1);

                var subrace2 = new Subrace
                {
                    Name = "Мефистофел",
                    Race = raceRep.Get(1002)
                };
                subraceRep.Save(subrace2);

                var subrace3 = new Subrace
                {
                    Name = "Зариэль",
                    Race = raceRep.Get(1002)
                };
                subraceRep.Save(subrace3);

                var subrace4 = new Subrace
                {
                    Name = "Высший эльф",
                    Race = raceRep.Get(1003)
                };
                subraceRep.Save(subrace4);

                var subrace5 = new Subrace
                {
                    Name = "Лесной эльф",
                    Race = raceRep.Get(1003)
                };
                subraceRep.Save(subrace5);

                var subrace6 = new Subrace
                {
                    Name = "Дроу Ллос",
                    Race = raceRep.Get(1006)
                };
                subraceRep.Save(subrace6);

                var subrace7 = new Subrace
                {
                    Name = "Дроу Селдарина",
                    Race = raceRep.Get(1006)
                };
                subraceRep.Save(subrace7);

                var subrace8 = new Subrace
                {
                    Name = "Золотой дварф",
                    Race = raceRep.Get(1009)
                };
                subraceRep.Save(subrace8);

                var subrace9 = new Subrace
                {
                    Name = "Щитовый дварф",
                    Race = raceRep.Get(1009)
                };
                subraceRep.Save(subrace9);

                var subrace10 = new Subrace
                {
                    Name = "Двергар",
                    Race = raceRep.Get(1009)
                };
                subraceRep.Save(subrace10);

                var subrace11 = new Subrace
                {
                    Name = "Высший полуэльф",
                    Race = raceRep.Get(1008)
                };
                subraceRep.Save(subrace11);

                var subrace12 = new Subrace
                {
                    Name = "Лесной полуэльф",
                    Race = raceRep.Get(1008)
                };
                subraceRep.Save(subrace12);

                var subrace13 = new Subrace
                {
                    Name = "Полуэльф-дроу",
                    Race = raceRep.Get(1008)
                };
                subraceRep.Save(subrace13);

                var subrace14 = new Subrace
                {
                    Name = "Легконогий полурослик",
                    Race = raceRep.Get(1007)
                };
                subraceRep.Save(subrace14);

                var subrace15 = new Subrace
                {
                    Name = "Крепкосердечный полурослик",
                    Race = raceRep.Get(1007)
                };
                subraceRep.Save(subrace15);

                var subrace16 = new Subrace
                {
                    Name = "Черный дракон",
                    Race = raceRep.Get(1010)
                };
                subraceRep.Save(subrace16);

                var subrace17 = new Subrace
                {
                    Name = "Синий дракон",
                    Race = raceRep.Get(1010)
                };
                subraceRep.Save(subrace17);

                var subrace18 = new Subrace
                {
                    Name = "Зеленый  дракон",
                    Race = raceRep.Get(1010)
                };
                subraceRep.Save(subrace18);

            }

            if (originRep.Count() <= 0)
            {
                var origin1 = new Оrigin
                {
                    History = "По ложному доносу бродячих артистов, одного из моих заклятых врагов, меня несправедливо обвинили в преступлении, которое я не совершал, теперь меня хотят казнить."
                };
                originRep.Save(origin1);

                var origin2 = new Оrigin
                {
                    History = "Я был изгнан на три года. Из-за пережитых лишений, я стал ненавидеть самого себя, теперь мне доставляет удовольствие, когда в мой адрес говорят оскорбительные слова."
                };
                originRep.Save(origin2);

                var origin3 = new Оrigin
                {
                    History = "Я серьезно заболел, из-за болезни я обнаружил в себе вторую личность, которая хочеть уничтожить меня."
                };
                originRep.Save(origin3);

                var origin4 = new Оrigin
                {
                    History = "На меня объявил охоту служитель культа. Поводом стали мои неудачи в искусстве."
                };
                originRep.Save(origin4);

                var origin5 = new Оrigin
                {
                    History = "Я был заключен в тюрьму на шеть лет. Из-за пережитых лишений, я стал верить в несуществующие вещи, я рискую потерять состояние."
                };
                originRep.Save(origin5);


            }
            Random rnd = new Random();
            if (heroRep.Count() <= 0)
            {
                for (int i = 0; i < 50; i++)
                {
                    var Hero = new Heros
                    {
                        Name = "Киборг Убийца" +i,
                        Bone = rnd.Next(1,20),
                        Class = classRep.Get(rnd.Next(1,12)),
                        Race = raceRep.Get(rnd.Next(1002,1011)),
                        Subrace = subraceRep.Get(rnd.Next(6,23)),
                        UserCreator = userRepository.GetAll().First(),
                        Оrigin = originRep.Get(rnd.Next(3,7)),
                     //   ImagePath = "/img/"

                    };
                    heroRep.Save(Hero);
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

        #region Movie Seed
        private void FillGenres(IServiceProvider services)
        {
            var genreRepository = services.GetService<IGenreRepository>();

            if (!genreRepository.GetAll().Any())
            {
                var genres = new List<Genre>()
            {
                new Genre{Name = "Драма"},
                new Genre{Name = "Фэнтези"},
                new Genre{Name = "Криминал"},
                new Genre{Name = "Комедия"},
                new Genre{Name = "Мелодрама"},
                new Genre{Name = "История"},
                new Genre{Name = "Военный"},
                new Genre{Name = "Биография"},
                new Genre{Name = "Приключения"},
                new Genre{Name = "Боевик"},
                new Genre{Name = "Мультфильм"},
                new Genre{Name = "Семейный"},
                new Genre{Name = "Музыка"},
                new Genre{Name = "Фантастика"},
                new Genre{Name = "Аниме"},
                new Genre{Name = "Триллер"},
                new Genre{Name = "Детектив"},
            };
                genreRepository.SaveRange(genres);
            }
        }
        private void FillMovies(IServiceProvider services)
        {
            var movieRepository = services.GetService<IMovieRepository>();

            var genreRepository = services.GetService<IGenreRepository>();
            var genres = genreRepository.GetAll();

            var movies = new List<Movie>
                {
                    new()
                    {
                        Title = "Зеленая миля",
                        ReleaseYear = 1999,
                        Rating = 9.1,
                        Country = "США",
                        Director = "Фрэнк Дарабонт",
                        Duration = 189,
                        Description =
                            "Пол Эджкомб — начальник блока смертников в тюрьме «Холодная гора», каждый из узников которого однажды проходит «зеленую милю» по пути к месту казни. Пол повидал много заключённых и надзирателей за время работы. Однако гигант Джон Коффи, обвинённый в страшном преступлении, стал одним из самых необычных обитателей блока.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Драма"),
                            genres.First(g => g.Name == "Фэнтези"),
                            genres.First(g => g.Name == "Криминал")
                        }
                    },

                    new()
                    {
                        Title = "Побег из Шоушенка",
                        ReleaseYear = 1994,
                        Rating = 9.1,
                        Country = "США",
                        Director = "Фрэнк Дарабонт",
                        Duration = 142,
                        Description =
                            "Бухгалтер Энди Дюфрейн обвинён в убийстве собственной жены и её любовника. Оказавшись в тюрьме под названием Шоушенк, он сталкивается с жестокостью и беззаконием, царящими по обе стороны решётки. Каждый, кто попадает в эти стены, становится их рабом до конца жизни. Но Энди, обладающий живым умом и доброй душой, находит подход как к заключённым, так и к охранникам, добиваясь их особого к себе расположения.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Драма")
                        }
                    },

                    new ()
                    {
                        Title = "Форрест Гамп",
                        ReleaseYear = 1994,
                        Rating = 8.9,
                        Country = "США",
                        Director = "Роберт Земекис",
                        Duration = 142,
                        Description =
                            "Сидя на автобусной остановке, Форрест Гамп — не очень умный, но добрый и открытый парень — рассказывает случайным встречным историю своей необыкновенной жизни.\nС самого малолетства парень страдал от заболевания ног, соседские мальчишки дразнили его, но в один прекрасный день Форрест открыл в себе невероятные способности к бегу. Подруга детства Дженни всегда его поддерживала и защищала, но вскоре дороги их разошлись.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Драма"),
                            genres.First(g => g.Name == "Комедия"),
                            genres.First(g => g.Name == "Мелодрама"),
                            genres.First(g => g.Name == "История"),
                            genres.First(g => g.Name == "Военный")
                        }
                    },

                    new()
                    {
                        Title = "Список Шиндлера",
                        ReleaseYear = 1993,
                        Rating = 8.8,
                        Country = "США",
                        Director = "Стивен Спилберг",
                        Duration = 195,
                        Description =
                            "Фильм рассказывает реальную историю загадочного Оскара Шиндлера, члена нацистской партии, преуспевающего фабриканта, спасшего во время Второй мировой войны почти 1200 евреев.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Драма"),
                            genres.First(g => g.Name == "Биография"),
                            genres.First(g => g.Name == "История"),
                            genres.First(g => g.Name == "Военный")
                        }
                    },

                    new()
                    {
                        Title = "1+1",
                        ReleaseYear = 2011,
                        Rating = 8.8,
                        Country = "Франция",
                        Director = "Оливье Накаш",
                        Duration = 112,
                        Description =
                            "Пострадав в результате несчастного случая, богатый аристократ Филипп нанимает в помощники человека, который менее всего подходит для этой работы, – молодого жителя предместья Дрисса, только что освободившегося из тюрьмы. Несмотря на то, что Филипп прикован к инвалидному креслу, Дриссу удается привнести в размеренную жизнь аристократа дух приключений.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Драма"),
                            genres.First(g => g.Name == "Комедия"),
                            genres.First(g => g.Name == "Биография"),
                        }
                    },

                    new ()
                    {
                        Title = "Властелин колец: Возвращение короля",
                        ReleaseYear = 2003,
                        Rating = 8.7,
                        Country = "Новая Зеландия",
                        Director = "Питер Джексон",
                        Duration = 201,
                        Description =
                            "Повелитель сил тьмы Саурон направляет свою бесчисленную армию под стены Минас-Тирита, крепости Последней Надежды. Он предвкушает близкую победу, но именно это мешает ему заметить две крохотные фигурки — хоббитов, приближающихся к Роковой Горе, где им предстоит уничтожить Кольцо Всевластья.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Фэнтези"),
                            genres.First(g => g.Name == "Приключения"),
                            genres.First(g => g.Name == "Драма"),
                            genres.First(g => g.Name == "Боевик"),
                        }
                    },

                    new ()
                    {
                        Title = "Тайна Коко",
                        ReleaseYear = 2017,
                        Rating = 8.7,
                        Country = "США",
                        Director = "Ли Анкрич",
                        Duration = 105,
                        Description =
                            "12-летний Мигель живёт в мексиканской деревушке в семье сапожников и тайно мечтает стать музыкантом. Тайно, потому что в его семье музыка считается проклятием. Когда-то его прапрадед оставил жену, прапрабабку Мигеля, ради мечты, которая теперь не даёт спокойно жить и его праправнуку. С тех пор музыкальная тема в семье стала табу. Мигель обнаруживает, что между ним и его любимым певцом Эрнесто де ла Крусом, ныне покойным, существует некая связь. Паренёк отправляется к своему кумиру в Страну Мёртвых, где встречает души предков. Мигель знакомится там с духом-скелетом по имени Гектор, который становится его проводником. Вдвоём они отправляются на поиски де ла Круса.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Мультфильм"),
                            genres.First(g => g.Name == "Фэнтези"),
                            genres.First(g => g.Name == "Комедия"),
                            genres.First(g => g.Name == "Приключения"),
                            genres.First(g => g.Name == "Семейный"),
                            genres.First(g => g.Name == "Музыка"),
                        }
                    },

                    new ()
                    {
                        Title = "Интерстеллар",
                        ReleaseYear = 2014,
                        Rating = 8.6,
                        Country = "США",
                        Director = "Кристофер Нолан",
                        Duration = 169,
                        Description =
                            "Когда засуха, пыльные бури и вымирание растений приводят человечество к продовольственному кризису, коллектив исследователей и учёных отправляется сквозь червоточину (которая предположительно соединяет области пространства-времени через большое расстояние) в путешествие, чтобы превзойти прежние ограничения для космических путешествий человека и найти планету с подходящими для человечества условиями.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Фантастика"),
                            genres.First(g => g.Name == "Драма"),
                            genres.First(g => g.Name == "Приключения"),
                        }
                    },

                    new ()
                    {
                        Title = "Унесённые призраками",
                        ReleaseYear = 2001,
                        Rating = 8.5,
                        Country = "Япония",
                        Director = "Хаяо Миядзаки",
                        Duration = 125,
                        Description =
                            "Тихиро с мамой и папой переезжает в новый дом. Заблудившись по дороге, они оказываются в странном пустынном городе, где их ждет великолепный пир. Родители с жадностью набрасываются на еду и к ужасу девочки превращаются в свиней, став пленниками злой колдуньи Юбабы. Теперь, оказавшись одна среди волшебных существ и загадочных видений, Тихиро должна придумать, как избавить своих родителей от чар коварной старухи.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Аниме"),
                            genres.First(g => g.Name == "Мультфильм"),
                            genres.First(g => g.Name == "Фэнтези"),
                            genres.First(g => g.Name == "Приключения"),
                            genres.First(g => g.Name == "Семейный"),
                        }
                    },

                    new ()
                    {
                        Title = "Шрэк",
                        ReleaseYear = 2001,
                        Rating = 8.1,
                        Country = "США",
                        Director = "Эндрю Адамсон",
                        Duration = 90,
                        Description =
                            "Жил да был в сказочном государстве большой зеленый великан по имени Шрэк. Жил он в гордом одиночестве в лесу, на болоте, которое считал своим. Но однажды злобный коротышка — лорд Фаркуад, правитель волшебного королевства, безжалостно согнал на Шрэково болото всех сказочных обитателей.\nИ беспечной жизни зеленого великана пришел конец. Но лорд Фаркуад пообещал вернуть Шрэку болото, если великан добудет ему прекрасную принцессу Фиону, которая томится в неприступной башне, охраняемой огнедышащим драконом.",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Мультфильм"),
                            genres.First(g => g.Name == "Фэнтези"),
                            genres.First(g => g.Name == "Мелодрама"),
                            genres.First(g => g.Name == "Комедия"),
                            genres.First(g => g.Name == "Приключения"),
                            genres.First(g => g.Name == "Семейный"),
                        }
                    },

                    new ()
                    {
                        Title = "Прислуга",
                        ReleaseYear = 2011,
                        Rating = 8.2,
                        Country = "США",
                        Director = "Тейт Тейлор",
                        Duration = 146,
                        Description =
                            "Американский Юг, на дворе 1960-е годы. Скитер только-только закончила университет и возвращается домой, в сонный городок Джексон, где никогда ничего не происходит. Она мечтает стать писательницей, вырваться в большой мир. Но для приличной девушки с Юга не пристало тешиться столь глупыми иллюзиями, приличной девушке следует выйти замуж и хлопотать по дому.\nМудрая Эйбилин на тридцать лет старше Скитер, она прислуживает в домах белых всю свою жизнь, вынянчила семнадцать детей и давно уже ничего не ждет от жизни, ибо сердце ее разбито после смерти единственного сына.\nМинни - самая лучшая стряпуха во всем Джексоне, а еще она самая дерзкая служанка в городе. И острый язык не раз уже сослужил ей плохую службу. На одном месте Минни никогда подолгу не задерживается. Но с Минни лучше не связываться даже самым высокомерным белым дамочкам. Двух черных служанок и белую неопытную девушку объединяет одно - обостренное чувство справедливости и желание хоть как-то изменить порядок вещей. Смогут ли эти трое противостоять целому миру? Сумеют ли они выжить в этой борьбе?",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Драма"),
                        }
                    },

                    new ()
                    {
                        Title = "Прежде чем мы расстанемся",
                        ReleaseYear = 2014,
                        Rating = 8.2,
                        Country = "США",
                        Director = "Крис Эванс",
                        Duration = 146,
                        Description =
                            "Американский Юг, на дворе 1960-е годы. Скитер только-только закончила университет и возвращается домой, в сонный городок Джексон, где никогда ничего не происходит. Она мечтает стать писательницей, вырваться в большой мир. Но для приличной девушки с Юга не пристало тешиться столь глупыми иллюзиями, приличной девушке следует выйти замуж и хлопотать по дому.\nМудрая Эйбилин на тридцать лет старше Скитер, она прислуживает в домах белых всю свою жизнь, вынянчила семнадцать детей и давно уже ничего не ждет от жизни, ибо сердце ее разбито после смерти единственного сына.\nМинни - самая лучшая стряпуха во всем Джексоне, а еще она самая дерзкая служанка в городе. И острый язык не раз уже сослужил ей плохую службу. На одном месте Минни никогда подолгу не задерживается. Но с Минни лучше не связываться даже самым высокомерным белым дамочкам. Двух черных служанок и белую неопытную девушку объединяет одно - обостренное чувство справедливости и желание хоть как-то изменить порядок вещей. Смогут ли эти трое противостоять целому миру? Сумеют ли они выжить в этой борьбе?",
                        Genres = new List<Genre>
                        {
                            genres.First(g => g.Name == "Драма"),
                            genres.First(g => g.Name == "Мелодрама"),
                            genres.First(g => g.Name == "Комедия"),
                        }
                },

                new ()
                {
                    Title = "Начало",
                    ReleaseYear = 2010,
                    Rating = 8.7,
                    Country = "США",
                    Director = "Кристофер Нолан",
                    Duration = 148,
                    Description =
                        "Кобб – талантливый вор, лучший из лучших в опасном искусстве извлечения: он крадет ценные секреты из глубин подсознания во время сна, когда человеческий разум наиболее уязвим. Редкие способности Кобба сделали его ценным игроком в привычном к предательству мире промышленного шпионажа, но они же превратили его в извечного беглеца и лишили всего, что он когда-либо любил.\nИ вот у Кобба появляется шанс исправить ошибки. Его последнее дело может вернуть все назад, но для этого ему нужно совершить невозможное – инициацию. Вместо идеальной кражи Кобб и его команда спецов должны будут провернуть обратное. Теперь их задача – не украсть идею, а внедрить ее. Если у них получится, это и станет идеальным преступлением.\nНо никакое планирование или мастерство не могут подготовить команду к встрече с опасным противником, который, кажется, предугадывает каждый их ход. Врагом, увидеть которого мог бы лишь Кобб.",
                    Genres = new List<Genre>
                    {
                        genres.First(g => g.Name == "Фантастика"),
                        genres.First(g => g.Name == "Боевик"),
                        genres.First(g => g.Name == "Триллер"),
                        genres.First(g => g.Name == "Драма"),
                        genres.First(g => g.Name == "Детектив"),
                    }
                },

                new ()
                {
                    Title = "Первому игроку приготовиться",
                    ReleaseYear = 2018,
                    Rating = 7.5,
                    Country = "США",
                    Director = "Стивен Спилберг",
                    Duration = 140,
                    Description =
                        "Действие фильма происходит в 2045 году, мир погружается в хаос и находится на грани коллапса. Люди ищут спасения в игре OASIS – огромной вселенной виртуальной реальности. Ее создатель, гениальный и эксцентричный Джеймс Холлидэй, оставляет уникальное завещание. Все его колоссальное состояние получит игрок, первым обнаруживший цифровое «пасхальное яйцо», которое миллиардер спрятал где-то на просторах OASISа. Запущенный им квест охватывает весь мир. Совершенно негероический парень по имени Уэйд Уоттс решает принять участие в состязании, с головой бросаясь в головокружительную, искажающую реальность погоню за сокровищами по фантастической вселенной, полной загадок, открытий и опасностей.",
                    Genres = new List<Genre>
                    {
                        genres.First(g => g.Name == "Фантастика"),
                        genres.First(g => g.Name == "Боевик"),
                        genres.First(g => g.Name == "Приключения"),
                    }
                },

                new ()
                {
                    Title = "По соображениям совести",
                    ReleaseYear = 2016,
                    Rating = 8.2,
                    Country = "Австралия",
                    Director = "Мэл Гибсон",
                    Duration = 139,
                    Description =
                        "Медик американской армии времён Второй мировой войны Десмонд Досс, который служил во время битвы за Окинаву, отказывается убивать людей и становится первым идейным уклонистом в американской истории, удостоенным Медали Почёта.",
                    Genres = new List<Genre>
                    {
                        genres.First(g => g.Name == "Биография"),
                        genres.First(g => g.Name == "Военный"),
                        genres.First(g => g.Name == "Драма"),
                        genres.First(g => g.Name == "История"),
                    }
                },
            };

            foreach (var movie in movies)
            {
                if (!movieRepository.IsMovieExist(movie.Title))
                {
                    movieRepository.Save(movie);
                }
            }
        }

        private void FillCollections(IServiceProvider services)
        {
            var collectionRepository = services.GetService<ICollectionRepository>();
            var ratingRepository = services.GetService<IRatingRepository>();
            if (!collectionRepository.GetAll().Any())
            {
                var userRepository = services.GetService<IUserRepository>();
                var user = userRepository.GetAll().First(user => user.Name == "Admin");

                var movieRepository = services.GetService<IMovieRepository>();
                var movies = movieRepository.GetAll();

                var collection = new Collection()
                {
                    Title = "10 лучших фильмов",
                    Description = "Лучшие фильмы всех времен.",
                    DateCreated = DateTime.Now,
                    AuthorId = user.Id,
                    Author = user,
                    Movies = new List<Movie>()
                    {
                        movies.First(m=>m.Title == "Зеленая миля"),
                        movies.First(m=>m.Title == "Побег из Шоушенка"),
                        movies.First(m=>m.Title == "Список Шиндлера"),
                        movies.First(m=>m.Title == "1+1"),
                        movies.First(m=>m.Title == "Властелин колец: Возвращение короля"),
                        movies.First(m=>m.Title == "Тайна Коко"),
                        movies.First(m=>m.Title == "Интерстеллар"),
                        movies.First(m=>m.Title == "Унесённые призраками"),
                        movies.First(m=>m.Title == "Шрэк"),
                        movies.First(m=>m.Title == "Начало"),
                    },
                };

                var ratings = new List<Rating>
                {
                    new Rating { Value = 9, UserId = user.Id },
                };
                collection.Ratings = ratings;

                foreach (var rating in ratings)
                {
                    rating.CollectionId = collection.Id;
                    rating.Collection = collection;
                    rating.User = user;
                    ratingRepository.Save(rating);
                }

                collectionRepository.Save(collection);
            };
        }
        #endregion
        private void FillRockBands(IServiceProvider provider)
        {
            var rockBandRepository = provider.GetService<IRockBandRepository>();
            if (!rockBandRepository.GetAll().Any())
            {
                var theOffspring = new RockBand
                {
                    FullName = "The Offspring",
                    CreatorId = 1
                };
                rockBandRepository.Save(theOffspring);

                for (int i = 0; i < MINIMUM_USER_COUNT; i++)
                {
                    var blink182 = new RockBand
                    {
                        FullName = $"Blink-18{i}",
                        CreatorId = 1
                    };
                    rockBandRepository.Save(blink182);
                }
            }
        }
        private void FillRockMembers(IServiceProvider provider)
        {
            var rockMemberRepository = provider.GetService<IRockMemberRepository>();
            if (rockMemberRepository.Count() < MINIMUM_USER_COUNT)
            {
                var paulMcCartney = new RockMember
                {
                    FullName = "Paul McCartney",
                    EntryYear = 1996,
                    YearOfBirth = 1996,
                    Genre = "Pop Rock",
                    CreatorId = 1
                };
                rockMemberRepository.Save(paulMcCartney);

                var johnLenon = new RockMember
                {
                    FullName = "John Lenon",
                    EntryYear = 1996,
                    YearOfBirth = 1996,
                    Genre = "Indi Rock",
                    CreatorId = 1
                };
                rockMemberRepository.Save(johnLenon);

                for (int i = 0; i < MINIMUM_USER_COUNT; i++)
                {
                    var slash = new RockMember
                    {
                        FullName = $"Slash {i}",
                        EntryYear = 1996,
                        YearOfBirth = 1996,
                        Genre = "Indi Rock",
                        CreatorId = 1
                    };
                    rockMemberRepository.Save(slash);
                }
            }
        }

        private void FillFootbal(IServiceProvider serviceProvider)
        {
            var footballClubRepository = serviceProvider.GetService<IFootballClubRepository>();
            var footballLeagueRepository = serviceProvider.GetService<IFootballLeagueRepository>();
            var userRepository = serviceProvider.GetService<IUserRepository>();
            if (!footballClubRepository.Any()  & !footballLeagueRepository.Any())
            {
                new FootballGenerator(footballClubRepository, footballLeagueRepository , userRepository).FillInfoAboutLeagues(5);
            }


        }
    }
}
