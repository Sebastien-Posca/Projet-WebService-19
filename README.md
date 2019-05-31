# SoCWS-2019 #

## Binôme 
Sébastien Posca - Aurélien Zintzmeyer
## Extensions
* Interface Web Form 
* Cache
* Monitoring
* Async

|Extensions  | POSCA Sébastien | ZINTZMEYER Aurélien|
|:----------:|:------:|:------:|
| IHM-WebForm|  50    |  50     |
| Async      |  60   |  0     |
| Cache      |  25    |  75    | 
| Monitoring |  75    |  25  |

## Architecture 

![](https://i.imgur.com/UhHGLb3.png)

### WebForm 
Projet contenant le webform pour la recherche et le webform du monitoring

### WCFServiceLibrary 
Projet content le service de recherche et le service de monitoring.
Le service de recherche utilise une classe Getter pour récupérer la réponse parsée d’une requête. Cette class Getter définit plusieurs politique de cache (classe CachePolicy customisée) et utilise la classe Cache


### Interface Web Form 
50% Sébastien 50% Aurélien

L’interface de recherche est polyvalente, si l’on tappes seulement un nom de ville toutes les stations sont affichées, si l’on tappe un bout de nom de ville on a accès à la liste des villes contenant cette sous-chaîn : on peut alors cliquer sur une des villes et le nom de la ville s'auto complète dans le champ. Si on fournit un nom de ville + un numéro de station incorrect on nous indique que le numéro est incorrect et on liste les stations de la ville, si on fournit un nom de ville + un bout de nom de station on affiche toutes les stations ayant ce bout de chaîne dans leur nom.

### Monitoring 
75% Sébastien 25% Aurélien

L'extension Monitoring permet à un l’administrateur de visualiser différentes métriques par rapport au Web service utilisé. Pour le moment on peut visualiser, le nom de la ville la plus recherché sur le site, un classement graphique des villes les plus recherchées, le nombre total de requêtes effectuées ainsi que le temps moyen qu’elles prennent pour s’exécuter. Pour cela j’ai créé un nouveau service soap intitulé MonitoringService, ainsi qu’une classe Monitoring qui stock statiquement des dictionnaires afin de conserver les données récupérés.

### Async 
100% Sébastien

### Cache 
75% Aurélien 25% Sébastien

Une politique de cache encapsule un mapping entre un préfix de clé et un temps de mise en cache en secondes. Le préfix permet de séparer les types de requêtes : celles concernant la liste des villes, liste des stations d’une ville ou le nombre de vélos pour une station, cette séparation est utile puisque certaines données comme les villes ou les stations d’une ville peuvent être conservées longtemps vu qu’elles sont rarement modifiées. La politique de cache est utilisée par la classe Cache qui va regarder la politique associée à un type de clé à chaque mise en cache d’un élément. On peut imaginer avoir 2 serveurs : un accédé principalement dans des zones avec beaucoup d’activité qui nécessite donc un temps de cache plus court et un autre serveur avec une politique de cache plus conservatrice seulement accédé pour les stations où le nombre de vélos change beaucoup plus lentement.

![](https://i.imgur.com/3pAxsm2.png)
