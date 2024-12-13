¨
MD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\SLC\IProductService.cs
	namespace 	
SLC
 
{		 
public

 

	interface

 
IProductService

 $
{ 
bool 
Delete 
( 
int 
id 
) 
; 
Products 
RetrieveProductById $
($ %
int% (
id) +
)+ ,
;, -
bool 
UpdateProduct 
( 
Products #
productToUpdate$ 3
)3 4
;4 5
List 
< 
Products 
> 
Filter 
( 
string $
name% )
)) *
;* +
}"" 
}## €
UD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\SLC\Properties\AssemblyInfo.cs
[ 
assembly 	
:	 

AssemblyTitle 
( 
$str 
) 
]  
[		 
assembly		 	
:			 

AssemblyDescription		 
(		 
$str		 !
)		! "
]		" #
[

 
assembly

 	
:

	 
!
AssemblyConfiguration

  
(

  !
$str

! #
)

# $
]

$ %
[ 
assembly 	
:	 

AssemblyCompany 
( 
$str 
) 
] 
[ 
assembly 	
:	 

AssemblyProduct 
( 
$str  
)  !
]! "
[ 
assembly 	
:	 

AssemblyCopyright 
( 
$str 0
)0 1
]1 2
[ 
assembly 	
:	 

AssemblyTrademark 
( 
$str 
)  
]  !
[ 
assembly 	
:	 

AssemblyCulture 
( 
$str 
) 
] 
[ 
assembly 	
:	 


ComVisible 
( 
false 
) 
] 
[ 
assembly 	
:	 

Guid 
( 
$str 6
)6 7
]7 8
[## 
assembly## 	
:##	 

AssemblyVersion## 
(## 
$str## $
)##$ %
]##% &
[$$ 
assembly$$ 	
:$$	 

AssemblyFileVersion$$ 
($$ 
$str$$ (
)$$( )
]$$) *¡
ND:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\SLC\ICategoryService.cs
	namespace 	
SLC
 
{		 
public

 

	interface

 
ICategoryService

 %
{ 

Categories 
Create 
( 

Categories $
category% -
)- .
;. /

Categories 
RetrieveById 
(  
int  #
id$ &
)& '
;' (
bool 
Delete 
( 
int 
id 
) 
; 
List 
< 

Categories 
> 
Filter 
(  
string  &
name' +
)+ ,
;, -
} 
} Ø
SD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\SLC\ILoginAttemptsService.cs
	namespace 	
SLC
 
{ 
public 

	interface !
ILoginAttemptsService *
{ 
bool

  
RegisterLoginAttempt

 !
(

! "
string

" (
username

) 1
)

1 2
;

2 3
bool 
IsAccountBlocked 
( 
string $
username% -
)- .
;. /
bool 
UnlockAccount 
( 
string !
username" *
)* +
;+ ,
bool 
ResetLoginAttempts 
(  
string  &
username' /
)/ 0
;0 1
List 
< 
LoginAttempts 
> 
GetAllLoginAttempts /
(/ 0
)0 1
;1 2
LoginAttempts +
RetrieveLoginAttemptsByUsername 5
(5 6
string6 <
username= E
)E F
;F G
} 
} 