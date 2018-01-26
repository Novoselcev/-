using System;
using VkNet;
using VkNet.Enums.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Magistral40.ClLib
{
    public class Vkontakte
    {
        VkApi api = new VkApi();

        public Vkontakte()
        {
            api.Authorize(new ApiAuthParams
            {
                ApplicationId = 6176094,
                Login = "+79005749555",
                Password = "pgs752233",
                Settings = Settings.All,
            });
        }

        public void sentMessage(long id, String message)
        {
            api.Messages.Send(id, false, message);
        }
    }
}