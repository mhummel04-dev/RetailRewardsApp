using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Microsoft.SemanticKernel;
using RetailRewardsApp.Core.Services;
using RetailRewardsApp.Core.Models;

namespace RetailRewardsApp.Core.Plugins;

public class CatalogPlugin
{
    private readonly SessionService _sessionService;
    private readonly ItemService _itemService;
    private readonly OfferService _offerService;
    public CatalogPlugin(SessionService sessionService)
    {
        _sessionService = sessionService;
        _itemService = new ItemService(sessionService);
        _offerService = new OfferService(sessionService);
    }

    [KernelFunction("get_available_items")]
    [Description("Returns the current list of items available for purchase in the store menu.")]
    public string GetAvailableItems()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Items available at the location the user has selected");

        foreach (var item in _sessionService.RegisteredLocation.Inventory)
        {
            string offers = string.Join(",", _sessionService.RegisteredLocation.Offers.Select(i => i.Description));

            sb.AppendLine("---");
            sb.AppendLine($"Id: " + item.Id);
            sb.AppendLine($"Name: " + item.Name);
            sb.AppendLine($"Price: " + item.Price);
            sb.AppendLine($"Description: " + item.Description);
            sb.AppendLine($"Stock: " + item.Stock);
            sb.AppendLine($"Offers Associated: " + offers);
        }

        return sb.ToString();
    }

    [KernelFunction("get_available_offers")]
    [Description("Returns the current list of active discounts, coupons, and rewards offers.")]
    public string GetAvailableOffers()
    {
        var sb = new StringBuilder();
        sb.AppendLine("Offers available at the location the user has selected");

        foreach (var offer in _sessionService.RegisteredLocation.Offers)
        {
            string items = string.Join(",", _sessionService.RegisteredLocation.Inventory.Select(i => i.Name));

            sb.AppendLine("---");
            sb.AppendLine($"Id: " + offer.Id);
            sb.AppendLine($"Description: " + offer.Description);
            sb.AppendLine($"Point Cost: " + offer.PointCost);
            sb.AppendLine($"Items Associated: " + items);
        }

        return sb.ToString();
    }

    [KernelFunction("get_offer_by_id")]
    [Description("Returns the full offer object via passing in its assigned GUID, titled Id in the variable/json")]
    public Offer GetOfferById(Guid Id)
    {
        Offer offerMinusItems = _offerService.GetOfferById(Id);
        offerMinusItems.Items.Clear();

        return offerMinusItems;
    }

    [KernelFunction("get_item_by_id")]
    [Description("Returns the full item object via passing in its assigned GUID, titled Id in the variable/json")]
    public Item GetItemById(Guid Id)
    {
        Item itemMinusOffers = _itemService.GetItemById(Id);
        itemMinusOffers.Offers.Clear();

        return itemMinusOffers;
    }
}
