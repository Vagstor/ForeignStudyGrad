using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace RHSoft.Study.Monitoring.Extra
{
    public class StatusCheck
    {
        public int Status;
        public string Error;
        public StatusCheck(int status)
        {
            if (status < 100)
            {
                this.Status = -1;
                switch (status)
                {
                    case 18:
                        this.Error = "Указанная запись не была найдена в кэше";
                        break;
                    case 2:
                        this.Error = "С точкой удаленной службы нельзя связаться на транспортном уровне";
                        break;
                    case 8:
                        this.Error = "Подключение было преждевременно закрыто";
                        break;
                    case 12:
                        this.Error = "Неожиданно закрыто подключение для запроса, задающего заголовок Keep-alive";
                        break;
                    case 17:
                        this.Error = "Получено сообщение, которое превышает ограничение, заданное при отправке запроса или получении ответа от сервера";
                        break;
                    case 1:
                        this.Error = "Служба разрешения имен не может разрешить имя узла";
                        break;
                    case 13:
                        this.Error = "Ожидается выполнение внутреннего асинхронного запроса";
                        break;
                    case 5:
                        this.Error = "Запрос являлся конвейерным запросом, и подключение было закрыто до получения запроса";
                        break;
                    case 7:
                        this.Error = "Ошибка на уровне протокола";
                        break;
                    case 15:
                        this.Error = "Службе разрешения имен не удалось разрешить имя узла прокси-сервера";
                        break;
                    case 3:
                        this.Error = "От удаленного сервера не получен полный ответ";
                        break;
                    case 6:
                        this.Error = "Запрос был отменен, был вызван метод Abort() или возникла ошибка, не поддающаяся классификации";
                        break;
                    case 19:
                        this.Error = "Этот запрос не разрешен политикой кэширования";
                        break;
                    case 20:
                        this.Error = "Этот запрос не разрешен прокси-сервером";
                        break;
                    case 10:
                        this.Error = "При установлении подключения с использованием SSL произошла ошибка";
                        break;
                    case 4:
                        this.Error = "Не удалось отправить полный запрос на удаленный сервер";
                        break;
                    case 11:
                        this.Error = "Ответ от сервера не является допустимым ответом HTTP";
                        break;
                    case 14:
                        this.Error = "В течение времени ожидания запроса ответ получен не был";
                        break;
                    case 9:
                        this.Error = "Не удалось проверить сертификат сервера";
                        break;
                    case 16:
                        this.Error = "Возникло исключение неизвестного типа";
                        break;
                }
            }

            else

            if ((status >= 100) && (status <= 400))
            {
                this.Status = status;
                this.Error = null;
            }

            else

            {
                this.Status = status;
                this.Error = ReasonPhrases.GetReasonPhrase(status);
            }
        }
    }
}
