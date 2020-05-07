using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForeignStudyGrad.Models;
using ForeignStudyGrad.Services;
using Microsoft.AspNetCore.Mvc;

namespace ForeignStudyGrad.Controllers
{
    public class ThemeController : Controller
    {

        private ThemeService _themeService;

        public ThemeController(ThemeService service)
        {
            _themeService = service;
        }
        [HttpGet]
        public IActionResult ShowTheme(Guid themeid)
        {
            ThemeViewModel vm = _themeService.GetThemeInfoById(themeid);
            return View(vm.Link,vm);
        }
        [HttpPost]
        public void SaveDictionaryWords(ThemeViewModel themeView)
        {
            List<string> WordList = new List<string> { "информация" , "исходная информация" , 
                "количество информации" , "количество информации", "обработка информации",
           "получать, получить (что?)", "получение информации", "сведения (о ком? о чём?)", "обработать, обрабатывать (что?)",
            "использовать (что?)", "использование", "научный", "технический", "политический", "результат",
            "вычислять, вычислить (что?)", "хранить (что?)", "сохранять, сохранить (что?)", "сохранение"};
            for (int i = 0; i < themeView.DictionaryList.Count(); i++)
            {
                themeView.DictionaryList[i].Word = WordList[i];
            }
            //themeView.DictionaryList[0].Word = "информация";
            //themeView.DictionaryList[1].Word = "исходная информация";
            //themeView.DictionaryList[2].Word = "количество информации";
            //themeView.DictionaryList[3].Word = "обработка информации";
            //themeView.DictionaryList[4].Word = "получать, получить (что?)";
            //themeView.DictionaryList[5].Word = "получение информации";
            //themeView.DictionaryList[6].Word = "сведения (о ком? о чём?)";
            //themeView.DictionaryList[7].Word = "обработать, обрабатывать (что?)";
            //themeView.DictionaryList[8].Word = "использовать (что?)";
            //themeView.DictionaryList[9].Word = "использование";
            //themeView.DictionaryList[10].Word = "научный";
            //themeView.DictionaryList[11].Word = "технический";
            //themeView.DictionaryList[12].Word = "политический";
            //themeView.DictionaryList[13].Word = "результат";
            //themeView.DictionaryList[14].Word = "вычислять, вычислить (что?)";
            //themeView.DictionaryList[15].Word = "хранить (что?)";
            //themeView.DictionaryList[16].Word = "сохранять, сохранить (что?)";
            //themeView.DictionaryList[17].Word = "сохранение";
            _themeService.AddDictionaryWords(themeView.DictionaryList, User.Identity.Name);
        }
    }
}