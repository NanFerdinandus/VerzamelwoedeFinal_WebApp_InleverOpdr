namespace WebApp_TestApp_W3_InlvrOpdr.Models;
using System.Collections.Generic;

public class Gebruiker
{
    public int Id { get; set; }
    public string Gebruikersnaam { get; set; }
    public string Wachtwoord { get; set; }

    // Navigatie-eigenschappen voor relaties
    public ICollection<Postzegel> Postzegels { get; set; } = new HashSet<Postzegel>();
    public ICollection<Favoriet> Favorieten { get; set; } = new HashSet<Favoriet>();
}