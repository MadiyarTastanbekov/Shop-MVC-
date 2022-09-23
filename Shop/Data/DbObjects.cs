using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DbObjects
    {
        public static void Initial(AppDbContext appDbContext)
        {
            try { 
            appDbContext.Database.EnsureCreated();
            //  if (!appDbContext.Categories.Any())
            //     appDbContext.Categories.AddRange(Categoriess.Select(c => c.Value));
            if (!appDbContext.Cars.Any())
            {
                appDbContext.AddRange(
                     new Car
                     {
                         name = "Tesla Model X",
                         shortDesc = "Полноразмерный электрический кроссовер производства компании Tesla. Прототип был впервые показан в Лос-Анджелесе 9 февраля 2012 года. " +
                   "Коммерческие поставки начались 29 сентября 2015 года.",
                         longDesc = "Ключевая особенность модели — автоматические двери в форме крыла чайки, которые Tesla называет «крыльями сокола»," +
                   " поскольку дверь имеет не жесткую Г-образную форму, а сгиб с изменяемым углом. Они облегчают доступ в автомобиль для пассажиров второго и третьего рядов," +
                   " а также требуют меньше места на парковке — 30 см до ближайшей стены или машины." +
                   " Задние двери будут оснащены специальными датчиками, призванными оберегать их от ударов об окружающие предметы при открытии.",
                         img = "/images/Tesla_Model_X_100D_Front.jpg",
                         price = 45000,
                         isFavourite = true,
                         iavailable = true,
                         Category = Categoriess["Электромобили"]
                     },
                new Car
                {
                    name = "Audi R8",
                    shortDesc = "Среднемоторный полноприводный спортивный автомобиль, производимый немецким автопроизводителем Audi с 2007 года.",
                    longDesc = "В базовой комплектации Audi R8 оснащается атмосферным двигателем V8 объёмом 4,2 литра, использующим технологию FSI, который вырабатывает максимальную мощность равную 420 лошадиным силам. " +
                    "Разгон от 0 до 100 км/ч составляет 4,6 секунды. Максимальная скорость в целях безопасности ограничена электроникой на отметке 301 км/ч",
                    img = "/images/Audi_R8_2015_(16649078228).jpg",
                    price = 40000,
                    isFavourite = false,
                    iavailable = true,
                    Category = Categoriess["Электромобили"]
                },
                 new Car
                 {
                     name = "BMW X7",
                     shortDesc = "Полноразмерный люксовый кроссовер немецкой компании BMW, который был запущен в производство с марта 2019. ",
                     longDesc = "Концепт автомобиля впервые был представлен на Международном автомобильном салоне во Франкфурте в 2017 году" +
                         "BMW X7 производится на заводе BMW в Спартанберге, США. У X7 будет 3 стандартных ряда сидений и он создан на той же платформе, что и BMW X5 и BMW X6",
                     img = "/images/BMW_X7_Genf_2019_1Y7A5624.jpg",
                     price = 50000,
                     isFavourite = false,
                     iavailable = false,
                     Category = Categoriess["Классические автомобили"]
                 },
                  new Car
                  {
                      name = "Toyoto 70",
                      shortDesc = "Легковой автомобиль компании Toyota. Производится на заводах в Японии, США, Австралии, России и Китае.",
                      longDesc = "Выпускается с 2017 года, в Российской Федерации старт продаж 2 апреля 2018 года. Автомобиль получил прежние двигатели 2,0 и 2,5 а также обновленную 3,5-литровую «шестерку» в сочетании с 8 диапазонным «автоматом»." +
                      " Двигатель 3,5 оснащён комбинированным типом впрыска, специально для российского рынка дефорсирован до 249 л. с." +
                         "Летом 2020 года модернизировали внешний вид и интерьер модели — передний бампер, экран мультимедийного комплекса, диагональ дисплея (увеличили максимальный размер до 9 дюймов), улучшенная шумоизоляция, " +
                         "появление доработанного комплекса Toyota Safety Sense 2.5+. Электронику научили удержанию автомобиля в полосе, автоматическому возобновлению движения после короткой остановки при включённом, а система экстренного торможения теперь распознаёт автомобили, едущие навстречу, а также пешеходов и велосипедистов.",
                      img = "/images/Toyota.jpg",
                      price = 70000,
                      isFavourite = false,
                      iavailable = true,
                      Category = Categoriess["Классические автомобили"]
                  },
                   new Car
                   {
                       name = "Lexus LX",
                       shortDesc = "Полноразмерный внедорожник компании Lexus выпускающийся с 1995 года. Настоящее поколение построено на базе автомобиля Toyota Land Cruiser 200. ",
                       longDesc = "Данное поколение внедорожника премиум-класса Lexus LX было представлено на автосалоне в Нью-Йорке еще в 2007 году. Но в Японии продажи Lexus LX, причём только флагманской модели LX570, начались в августе 2015 года, когда автомобиль прошел основательное омоложение. Будучи еще не самой дорогой моделью в ряду Lexus (есть еще Lexus LS гибрид)," +
                       " LX570 занимает только пятую строчку в рейтинге популярности на внутреннем японском рынке",
                       img = "/images/Lexus_LX_P4250848.jpg",
                       price = 95000,
                       isFavourite = true,
                       iavailable = true,
                       Category = Categoriess["Классические автомобили"]
                   },
                     new Car
                     {
                         name = "Mercedes-Benz R231",
                         shortDesc = "Новое поколение лёгких спортивных автомобилей немецкой фирмы Mercedes-Benz, пришедшее на смену модели R230 в 2012 году." +
                         " Новые модели SL легче, чем предыдущие, так как многие детали выполнены полностью из алюминия.",
                         longDesc = "",
                         img = "/images/Mersedes.jpg",
                         price = 90000,
                         isFavourite = true,
                         iavailable = true,
                         Category = Categoriess["Классические автомобили"]
                     }

                    );
            }
            appDbContext.SaveChanges(); }
            catch (Exception ex)
            {

            }

        }
        private static Dictionary<string, Category> diccategory;
        public static Dictionary<string, Category> Categoriess
        {
            get {
                if (diccategory == null) {
                    var list = new Category[]
                    {
                   new Category {categoryName="Электромобили",desc="Машины электро двигетелем"},
                  new Category{categoryName="Классические автомобили",desc="Машины с бензином и газом"}
                    };
                    diccategory = new Dictionary<string, Category>();
                    foreach(Category category in list)
                    {
                        diccategory.Add(category.categoryName, category);
                    }

                }
                return diccategory;
            }
          }
         

        }
    }

