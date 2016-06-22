# Bank Client<>Server

A repository to practice coding and help the community of coders. If there are any questions, just let me know.

I make use only of embed libraries. 

This piece of software is composed by trade of packets utilizing **Socket** library, serialization and deserialization of XML, inheritance and so on.
I hope that maybe useful to anyone in the community.

The software it still little buggy, but it's pretty usable and with good examples.

## TODO List

  * [ ] Save the changes maked on the account entity to the "physical" file XML;

## Bugs

Any bug, just report to me that I will work on it.

## Updates

I will keep it updated, so if you have some idea to share, just let me know.

## Database

The database is a XML file that must be at specified path:
{BankServerROOT}/DB/Accounts.xml
`BankServerROOT: The path where BankServer.exe is.`

### XML DB Structure

```
<?xml version="1.0" encoding="ISO-8859-1" ?>
	<Accounts>
			<Account ID="1" PASS="1">
				<Name>Testing.</Name>
				<Tel>(11) 1111-1111</Tel>
				<Balance>1000</Balance>
			</Account>
	</Accounts>
```

## Questions

Any questions, just let me know.