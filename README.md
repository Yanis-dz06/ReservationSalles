# ReservationSalles

Application .NET MAUI permettant de consulter les salles disponibles et de gérer des réservations simulées.

## Présentation du projet

**ReservationSalles** est une application développée avec **.NET MAUI, C#, XAML et Visual Studio 2022** dans le cadre du cours de programmation.

L'application permet de :

- consulter les salles disponibles ;
- afficher les informations détaillées d'une salle ;
- effectuer une réservation ;
- vérifier la disponibilité d'une salle ;
- consulter les réservations effectuées.

Les données utilisées dans le projet sont des données de démonstration. Les réservations sont conservées temporairement en mémoire pendant l'exécution de l'application.

Aucune base de données n'est utilisée dans cette version du projet.

## Fonctionnalités

### Tableau de bord

Le tableau de bord permet de :

- afficher le nombre de salles disponibles ;
- afficher le nombre de réservations simulées ;
- accéder à la liste des salles.

### Liste des salles

La liste affiche les informations principales de chaque salle :

- nom de la salle ;
- capacité ;
- localisation ;
- disponibilité ;
- équipements ;
- bouton permettant de consulter les détails.

Les salles utilisées dans l'application sont :

- Salle 101
- Salle 102
- Salle 201
- Salle 202

### Détail d'une salle

La page de détail permet de consulter :

- le nom de la salle ;
- la capacité ;
- la localisation ;
- la disponibilité ;
- les équipements disponibles.

Un bouton **Réserver** permet d'accéder au formulaire de réservation.

### Réservation

Le formulaire de réservation permet de saisir :

- le nom de l'utilisateur ;
- la salle ;
- la date ;
- la plage horaire.

Lorsque l'utilisateur accède au formulaire depuis la page de détail, la salle sélectionnée est transmise à la page de réservation.

### Validation

Le formulaire vérifie les informations nécessaires avant de confirmer la réservation.

Les informations vérifiées sont :

- le nom de l'utilisateur ;
- la salle sélectionnée ;
- la plage horaire.

Une alerte est affichée lorsqu'une information obligatoire est manquante.

Après une saisie valide, une confirmation affiche :

- le nom de l'utilisateur ;
- la salle ;
- la date ;
- la plage horaire.

### Vérification des disponibilités

L'application vérifie si une salle est déjà réservée pour la même date et la même plage horaire.

Une même salle ne peut donc pas être réservée deux fois au même moment.

Si la salle est déjà réservée, un message **Salle indisponible** est affiché et la nouvelle réservation n'est pas ajoutée.

### Mes réservations

La page **Mes réservations** permet d'afficher les réservations effectuées pendant l'exécution de l'application.

Pour chaque réservation, l'application affiche :

- le nom de la salle ;
- le nom de l'utilisateur ;
- la date ;
- la plage horaire.

La page est accessible depuis le menu de navigation.

## Architecture MVVM

L'application utilise l'architecture **MVVM (Model-View-ViewModel)** selon les notions étudiées dans le cours.

Cette architecture permet de séparer les données, l'interface et la logique de présentation.

### Models

Le dossier `Models` contient les classes qui représentent les données et la gestion des réservations :

- `Salle.cs` : représente une salle.
- `Reservation.cs` : représente une réservation.
- `ReservationService.cs` : gère les réservations et la vérification des doublons.

### Views

Le dossier `Views` contient les interfaces de l'application réalisées avec XAML :

- `DashboardPage` : tableau de bord.
- `SallesPage` : liste des salles.
- `SalleDetailPage` : détails d'une salle.
- `ReservationPage` : formulaire de réservation.
- `ReservationsPage` : liste des réservations.

### ViewModels

Le dossier `ViewModels` contient la logique de présentation :

- `DashboardViewModel.cs`
- `SallesViewModel.cs`
- `SalleDetailViewModel.cs`
- `ReservationViewModel.cs`
- `ReservationsViewModel.cs`

### Binding

Les propriétés des ViewModels sont reliées aux éléments de l'interface avec les `Binding`.

Par exemple :

```xml
<CollectionView ItemsSource="{Binding Reservations}"
                SelectionMode="None">
```

Le `BindingContext` permet de connecter une View à son ViewModel.

Exemple :

```csharp
BindingContext = new ReservationViewModel();
```

### Command

Les actions des boutons peuvent être gérées avec des `Command` dans les ViewModels.

Par exemple :

```xml
<Button
    Text="Réserver"
    Command="{Binding ReserverCommand}" />
```

Cette organisation permet de séparer la logique de présentation du code de l'interface.

## Navigation

La navigation de l'application utilise **AppShell** et les routes .NET MAUI.

Le parcours principal est :

```text
Tableau de bord
       ↓
Liste des salles
       ↓
Détail d'une salle
       ↓
Réserver
       ↓
Formulaire de réservation
       ↓
Validation
       ↓
Confirmation
       ↓
Mes réservations
```

Les principales pages sont :

- `DashboardPage`
- `SallesPage`
- `SalleDetailPage`
- `ReservationPage`
- `ReservationsPage`

La salle sélectionnée est transmise de `SalleDetailPage` vers `ReservationPage`.

## Structure du projet

```text
ReservationSalles
│
├── Images
│
├── Models
│   ├── Salle.cs
│   ├── Reservation.cs
│   └── ReservationService.cs
│
├── ViewModels
│   ├── DashboardViewModel.cs
│   ├── SallesViewModel.cs
│   ├── SalleDetailViewModel.cs
│   ├── ReservationViewModel.cs
│   └── ReservationsViewModel.cs
│
├── Views
│   ├── DashboardPage.xaml
│   ├── DashboardPage.xaml.cs
│   ├── SallesPage.xaml
│   ├── SallesPage.xaml.cs
│   ├── SalleDetailPage.xaml
│   ├── SalleDetailPage.xaml.cs
│   ├── ReservationPage.xaml
│   ├── ReservationPage.xaml.cs
│   ├── ReservationsPage.xaml
│   └── ReservationsPage.xaml.cs
│
├── Platforms
│
├── Resources
│   └── Styles
│
├── App.xaml
├── App.xaml.cs
├── AppShell.xaml
├── AppShell.xaml.cs
├── MainPage.xaml
├── MauiProgram.cs
└── README.md
```

## Technologies utilisées

- C#
- .NET MAUI
- XAML
- Visual Studio 2022
- Git
- GitHub

## Gestion des réservations

Les réservations sont conservées temporairement dans une liste en mémoire à l'aide de `ReservationService`.

L'application vérifie qu'une même salle ne possède pas déjà une réservation pour la même date et la même plage horaire.

Si une réservation identique existe déjà, l'application affiche un message indiquant que la salle est indisponible.

Les réservations ne sont pas sauvegardées de façon permanente et sont perdues lorsque l'application est arrêtée.

## Données

Les salles utilisées dans l'application sont des données de démonstration :

- Salle 101
- Salle 102
- Salle 201
- Salle 202

Les réservations sont simulées et conservées temporairement en mémoire.

Aucune base de données n'est utilisée dans cette version du projet.

## Captures d'écran

### Tableau de bord

![Tableau de bord](Images/dashboard.png)

### Liste des salles

![Liste des salles](Images/salles.png)

### Détail d'une salle

![Détail d'une salle](Images/salle-detail.png)

### Formulaire de réservation

![Formulaire de réservation](Images/reservation.png)

### Confirmation de réservation

![Confirmation de réservation](Images/reservation-confirmation.png)

### Mes réservations

![Mes réservations](Images/reservations.png)

## Guide d'exécution

1. Ouvrir le projet `ReservationSalles` dans Visual Studio 2022.
2. Vérifier que .NET MAUI est installé.
3. Ouvrir la solution du projet.
4. Sélectionner **Windows Machine** comme cible d'exécution.
5. Appuyer sur **F5** pour lancer l'application.
6. Le tableau de bord s'affiche au démarrage.
7. Cliquer sur **Voir les salles**.
8. Sélectionner une salle et cliquer sur **Voir**.
9. Consulter les détails de la salle.
10. Cliquer sur **Réserver**.
11. Entrer le nom de l'utilisateur.
12. Choisir une salle.
13. Choisir une date.
14. Choisir une plage horaire.
15. Cliquer sur **Réserver**.
16. Une confirmation de réservation s'affiche.
17. Ouvrir le menu **☰**.
18. Cliquer sur **Mes réservations** pour consulter les réservations effectuées.

## Projet

Projet réalisé dans le cadre du cours de programmation avec **.NET MAUI**.