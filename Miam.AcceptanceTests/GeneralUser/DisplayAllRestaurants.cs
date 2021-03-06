﻿using System;
using Miam.AcceptanceTests.Admin;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.BDDfy;

namespace Miam.AcceptanceTests.GeneralUser
{
    //Todo: à compléter
    [TestClass]
    [Story(
        Title = "Un utilisateur non authentifié peut voir la liste des restaurants",
        AsA = "En tant qu'utilisateur",
        IWant = "Je veux voir la liste des restaurants avec la moyenne des critiques",
        SoThat = "Afin de choisir un restaurant")]
    public class DisplayAllRestaurants : AdminTests
    {
        [TestMethod, Ignore]
        public void voir_la_liste_des_restaurants()
        {
            this.Given(x => des_restaurants_avec_des_critiques())
                .When(x => l_utlisateur_accède_au_site())
                .Then(x => l_utlisateur_voit_une_liste_de_restaurants_avec_la_moyenne_des_critiques())
                .BDDfy();
        }

        private void des_restaurants_avec_des_critiques()
        {
            throw new NotImplementedException();
        }

        private void l_utlisateur_accède_au_site()
        {
            throw new NotImplementedException();
        }

        private void l_utlisateur_voit_une_liste_de_restaurants_avec_la_moyenne_des_critiques()
        {
            throw new NotImplementedException();
        }
    }
}