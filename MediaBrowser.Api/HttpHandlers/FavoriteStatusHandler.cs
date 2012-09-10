﻿using MediaBrowser.Common.Net.Handlers;
using MediaBrowser.Model.DTO;
using MediaBrowser.Model.Entities;
using System.ComponentModel.Composition;
using System.Net;
using System.Threading.Tasks;

namespace MediaBrowser.Api.HttpHandlers
{
    /// <summary>
    /// Provides a handler to set user favorite status for an item
    /// </summary>
    [Export(typeof(BaseHandler))]
    public class FavoriteStatusHandler : BaseSerializationHandler<DTOUserItemData>
    {
        public override bool HandlesRequest(HttpListenerRequest request)
        {
            return ApiService.IsApiUrlMatch("FavoriteStatus", request);
        }

        protected override Task<DTOUserItemData> GetObjectToSerialize()
        {
            // Get the item
            BaseItem item = ApiService.GetItemById(QueryString["id"]);

            // Get the user
            User user = ApiService.GetUserById(QueryString["userid"], true);

            // Get the user data for this item
            UserItemData data = item.GetUserData(user, true);

            // Set favorite status
            data.IsFavorite = QueryString["isfavorite"] == "1";

            return Task.FromResult<DTOUserItemData>(ApiService.GetDTOUserItemData(data));
        }
    }
}