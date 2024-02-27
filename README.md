Detta projekt löstes genoom att jag tog bort så kallade "cirkulära referenser mellan modellerna TicketModel, TagModel och TicketTagModel. 

Cirkulära referenser kan uppstå när det finns en oändlig loop eller kedja av referenser mellan mina objekt. Detta sker när två objekt refererar till varandra, antingen direkt eller indirekt.

I mitt fall, om TicketTagModel innehåller referenser till både TicketModel och TagModel, och om dessa modeller också refererar tillbaka till TicketTagModel, så uppstår en oändlig loop när detta ska serialisera eller manipuleras.

