# Kursmanager

Dies ist ein Übungsprogramm zur Eingabe und Ausgabe von Kursen via CSV-Datei (Kommasepariere Liste). In zwei Gruppen sind Konsolenprogramme für jeweils Eingabe beziehungsweise Ausgabe von Kursen entstanden:

* [KursManager](KursManager): 
	* Einlesen der Kurse und Teilnehmer aus CSV-Dateien
	* Ausgabe der Kurse und Teilnehmer in er Konsole
	* Abfrage 
		* von momentanen Kursen
		* in welchem Kurs ein Teilnehmer momenan ist
		* Kurse an einem bestimmten Datum
* [KursManager2](KursManager2):
	* Eingabe von Kursen und Teilnehmern
	* Wegschreiben als CSV-Datei

Die CSV-Dateien werden unter Dokumente/Kurs.csv bzw. Dokumente/Teilnehmer.csv abgelegt.

Ein Beispiel für den Inhalt einer Kurs.csv:

```
Name des Kurses, Trainername, Veranstaltungstage
C#1, Anne, 3.4.2024 5.9.2024
C#2, Mark, 22.9.2024 25.9.2024
```

Ein Beispiel für den Inhalt einer Teilnehmer.csv:

```
Name des Teilnehmers, Alter, Kursname
Max, 19, C#1
Manu, 19, C#1
Martin, 23, C#1
Julius, 8, C#2
Jonas, 18, C#2
Janin, 18, C#2
Jana, 19, C#2
```