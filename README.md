# PostTrades API
> OpenClassrooms Projet 7 : Rendez votre back-end .NET plus flexible avec une API REST. [Page projet](https://openclassrooms.com/fr/paths/882/projects/1455)


## Informations Générales
Implémenter les méthodes de l'API RESTful des entités financières utilisées pour gérer des transactions. Gérer l'authentification avec Asp.Net Core Identity Framework et l'autorisation via des Tokens JWT (JSON Web Tokens). Mettre en place des logs sur les appels des endpoints. Gérer la validation des champs des formulaires pour contrôler les données en entrée. Développer des tests unitaires couvrant les méthodes des entités de l'API.
S'assurer que le développement répond aux recommandations client. [Recommandations](https://course.oc-static.com/projects/784_D%C3%A9veloppeur+back-end+.Net/P7/P7+Checklist+de+recommandations.pdf)


## Technologies utilisées
- .NET framework - 6.0
- Microsoft.EntityFrameworkCore - 6.0.16
- Microsoft.EntityFrameworkCore.SqlServer - 6.0.16
- Microsoft.EntityFrameworkCore.Tools - 6.0.16
- Microsoft.AspNetCore.Identity.EntityFrameworkCore - 6.0.16
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore - 6.0.16
- Microsoft.AspNetCore.Authentication.JwtBearer - 6.0.16
- Microsoft.VisualStudio.Web.CodeGeneration.Design- 6.0.16
- Swashbuckle.AspNetCore - 6.5.0
- Serilog - 4.0.0
- Serilog.Sinks.Console - 4.0.0
- Serilog.Sinks.File - 4.0.0

## Installation
1. Cloner le projet localement sur votre marchine.
	```
	git clone --single-branch --branch dev https://github.com/Kingofzehill/P7_API_REST_Back-end.NET.git
	```
2. Modifier le fichier appsettings.json en remplaçant la valeur de Server par le nom du serveur sur lequel vous voulez créer votre base de donnée.
	```
		"ConnectionStrings": {
	  "DefaultConnection": "Server=.;Database=P7_PostTrades_API_01;Trusted_Connection=True;MultipleActiveResultSets=true"
	},
	```
3. Créer la base de données en ouvrant dans Visual Studio la Console du Gestionnaire de Package (Menu Affichage / Autres fenêtres).
Taper la commande add-migration InitialCreate.
Taper la commande update-databe.
4. Lancer l'application en débuggage, elle doit s'ouvrir sur l'interface utilisateur Swagger.

## Utilisation
Pour utiliser les méthodes des entités de l'API, vous devez vous authentifier puis vous autoriser avec le token généré lors de l'authentification.
Authentifier vous avec la méthode suivante :
**Route :** `POST /Auth/login`
```
{  
	"username":  "admin",  
	"password":  "*ApiUseAdmin78Xls*"  
}
Si la connexion utilisateur (code réponse 200) est réussie, copier le token fourni en réponse.
```
**Réponse :**
```
{  
	"token":  "votre-token"
}
```

Pour autoriser votre accès aux routes protégées des méthodes de l'API, cliquez sur le bouton `Authorize` en haut à droite de l'interface utilisateur swagger et entrer le token précédé de la mention Bearer : `Bearer <votre-token>`.

## Contact
[GitHub KingOfZeHill](https://github.com/Kingofzehill)
Email KingOfZeHill : kingofzehill@gmail.com

