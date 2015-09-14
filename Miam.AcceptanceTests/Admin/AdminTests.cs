﻿using FluentAssertions;
using Miam.AcceptanceTests.Automation.PageObjects;
using Miam.AcceptanceTests.Automation.Seleno;
using Miam.Domain.Entities;
using Miam.TestUtility.Seed;

namespace Miam.AcceptanceTests.Admin
{
    public class AdminTests : BaseAcceptanceTests
    {
        protected MiamUser _userAdmin;
        protected Restaurant _restaurant1;

        protected void un_administrateur_authentifé()
        {
            _userAdmin = TestData.MiamUserAdmin;
            TestHelperApi.Users.Add(_userAdmin);

            Host.Instance.NavigateToInitialPage<HomePage>()
                .NavigationMenu
                .ClickLogin()
                .LoginAs(_userAdmin.Email, TestData.ADMIN_PLAIN_TEXT_PASSWORD);
        }
        protected void un_restaurant()
        {
            _restaurant1 = TestData.Restaurant1;
            TestHelperApi.Restaurants.Add(_restaurant1);
        }

        protected void AssertRestaurantsShouldBeEquivalent(Restaurant expectedRestaurant, Restaurant obtainedRestaurant)
        {
            expectedRestaurant.Name.ShouldBeEquivalentTo(obtainedRestaurant.Name);
            expectedRestaurant.City.ShouldBeEquivalentTo(obtainedRestaurant.City);
            expectedRestaurant.Country.ShouldBeEquivalentTo(obtainedRestaurant.Country);
        }

        protected void AssertContactDetailsShouldBeEquivalent(RestaurantContactDetail contactDetailsesExpected, RestaurantContactDetail contactDetailsesObtained)
        {
            contactDetailsesExpected.FaxPhone.ShouldBeEquivalentTo(contactDetailsesObtained.FaxPhone);
            contactDetailsesExpected.OfficePhone.ShouldBeEquivalentTo(contactDetailsesObtained.OfficePhone);
            contactDetailsesExpected.TwitterAlias.ShouldBeEquivalentTo(contactDetailsesObtained.TwitterAlias);
            contactDetailsesExpected.Facebook.ShouldBeEquivalentTo(contactDetailsesObtained.Facebook);
            contactDetailsesExpected.WebPage.ShouldBeEquivalentTo(contactDetailsesObtained.WebPage);
        }
    }
}
