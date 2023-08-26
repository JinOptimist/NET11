using DALInterfaces.Models;
using DALInterfaces.Models.Movies;
using DALInterfaces.Repositories;
using DALInterfaces.Repositories.Movies;
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
                FillGenres(scope.ServiceProvider);
                FillMovies(scope.ServiceProvider);
                FillCollections(scope.ServiceProvider);
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
            if (!movieRepository.GetAll().Any())
            {
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
                movieRepository.SaveRange(movies);
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
    }
}
