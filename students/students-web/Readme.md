Gestione studenti

Questa applicazione ha lo scopo di gestire una anagrafica studenti.
Gli strumenti utilizzati sono:
- Visual Studio 2019
- Microsoft MVC
- SQL Server
- Git

Il repository è suddiviso in 6 branch. In ogni branch viene svolto 

- 01-scaffholding : Creazione del progetto MVC con i default di visual studio 2019
- 02-students-view: Creazione di una pagina che visualizza una lista di studenti
- 03-students-view-controller: La lista di studenti viene popolata nel controller Home, utilizzando dei dati "Mokkati"
- 04-students-from-db: La lista di studenti viene popolata nel controller tramite accesso al database
- 05-refactoring: Rimozione dei file generati automaticamente da visual studio e non più utilizzati
- 06-students-crud: Implementazione di Inserimento, Modifica, Cancellazione di uno studente (CRUD)

Spunti per possibili estensioni:

- Aggiunta di una tabella corsi con relativo CRUD
- Aggiunta di una tabella studenti<->corsi (1->n)
- Aggiunta/Rimozione studente-corso : pagina di assegnazione corsi ad uno studente
- Bootstrap: aggiungere bootstrap e formattare il layout utilizzando i componenti standard forniti dal framework
- AJAX: tramite una chiamata AJAX (usando jQuery), chiamare una action che ritorna un json con la lista di corsi di assegnati allo studente.
Questa lista deve essere visualizzata in un tooltip