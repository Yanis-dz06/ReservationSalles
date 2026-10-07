# ReservationSalles

Application .NET MAUI permettant de consulter les salles disponibles et de gérer des réservations simulées.

## Présentation du projet

ReservationSalles est une application développée avec .NET MAUI dans le cadre du cours de programmation.

L'application permet de consulter les salles, d'afficher leurs informations détaillées, de faire une réservation et de consulter les réservations effectuées.

Les données du projet sont des données de démonstration. Les réservations sont conservées en mémoire pendant l'exécution de l'application et ne sont pas enregistrées dans une base de données.

## Fonctionnalités

### Tableau de bord

Le tableau de bord permet de :

- Afficher le nombre de salles disponibles
- Afficher le nombre de réservations simulées
- Accéder à la liste des salles

### Liste des salles

La liste affiche les informations principales de chaque salle :

- Nom de la salle
- Capacité
- Localisation
- Disponibilité
- Équipements
- Bouton pour consulter les détails

Les salles utilisées dans l'application sont :

- Salle 101
- Salle 102
- Salle 201
- Salle 202

### Détail d'une salle

La page de détail permet de consulter :

- Le nom de la salle
- La capacité
- La localisation
- La disponibilité
- Les équipements disponibles

Un bouton **Réserver** permet d'accéder au formulaire de réservation.

### Réservation

Le formulaire de réservation permet de saisir :

- Le nom de l'utilisateur
- La salle
- La date
- La plage horaire

Lorsque l'utilisateur accède au formulaire depuis la page de détail, la salle sélectionnée est automatiquement transmise au formulaire.

### Validation

Le formulaire vérifie les informations nécessaires avant de confirmer la réservation.

Les informations vérifiées sont :

- Le nom de l'utilisateur
- La salle sélectionnée
- La plage horaire

Une alerte est affichée lorsqu'une information obligatoire est manquante.

Après une saisie valide, une confirmation affiche :

- Le nom de l'utilisateur
- La salle
- La date
- La plage horaire

### Vérification des disponibilités

L'application vérifie si la salle est déjà réservée pour la même date et la même plage horaire.

Une même salle ne peut donc pas être réservée deux fois au même moment.

Si la salle est déjà réservée, un message **Salle indisponible** est affiché et la nouvelle réservation n'est pas ajoutée.

### Mes réservations

La page **Mes réservations** permet d'afficher les réservations effectuées pendant l'exécution de l'application.

Pour chaque réservation, l'application affiche :

- Le nom de la salle
- Le nom de l'utilisateur
- La date
- La plage horaire

La page est accessible directement depuis le menu de navigation.

## Navigation

Le parcours principal de l'application est :

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