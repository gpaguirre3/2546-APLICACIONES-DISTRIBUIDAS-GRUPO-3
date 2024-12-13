î
OD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\DAL\RepositoryFactory.cs
	namespace 	
DAL
 
{ 
public		 

class		 
RepositoryFactory		 "
{

 
public 
static 
IRepository !
CreateRepository" 2
(2 3
)3 4
{ 	
return 
new 
EFRepository #
(# $
new$ '
Entities( 0
.0 1
Sales_DBEntities1 A
(A B
)B C
)C D
;D E
} 	
} 
} €
UD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\DAL\Properties\AssemblyInfo.cs
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
]$$) *È
ID:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\DAL\IRepository.cs
	namespace		 	
DAL		
 
{

 
public 

	interface 
IRepository  
:! "
IDisposable# .
{ 
TEntity 
Create 
< 
TEntity 
> 
(  
TEntity  '
toCreate( 0
)0 1
where2 7
TEntity8 ?
:@ A
classB G
;G H
bool 
Delete 
< 
TEntity 
> 
( 
TEntity $
toDelete% -
)- .
where/ 4
TEntity5 <
:= >
class? D
;D E
bool 
Update 
< 
TEntity 
> 
( 
TEntity $
toUpdate% -
)- .
where/ 4
TEntity5 <
:= >
class? D
;D E
TEntity 
Retrieve 
< 
TEntity  
>  !
(! "

Expression" ,
<, -
Func- 1
<1 2
TEntity2 9
,9 :
bool; ?
>? @
>@ A
criteriaB J
)J K
where 
TEntity 
: 
class !
;! "
List 
< 
TEntity 
> 
Filter 
< 
TEntity $
>$ %
(% &

Expression& 0
<0 1
Func1 5
<5 6
TEntity6 =
,= >
bool? C
>C D
>D E
criteriaF N
)N O
where 
TEntity 
: 
class !
;! "
List 
< 
TEntity 
> 
GetAll 
< 
TEntity $
>$ %
(% &
)& '
where( -
TEntity. 5
:6 7
class8 =
;= >
} 
} Î5
JD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\DAL\EFRepository.cs
	namespace

 	
DAL


 
{ 
internal 
class 
EFRepository 
:  !
IRepository" -
{ 
	DbContext 

_dbContext 
; 
public 
EFRepository 
( 
	DbContext %
	dbContext& /
)/ 0
{ 	

_dbContext 
= 
	dbContext "
;" #
} 	
public 
TEntity 
Create 
< 
TEntity %
>% &
(& '
TEntity' .
toCreate/ 7
)7 8
where9 >
TEntity? F
:G H
classI N
{ 	
TEntity 
result 
= 
default $
;$ %
try 
{ 

_dbContext 
. 
Set 
< 
TEntity &
>& '
(' (
)( )
.) *
Add* -
(- .
toCreate. 6
)6 7
;7 8

_dbContext 
. 
SaveChanges &
(& '
)' (
;( )
result   
=   
toCreate   !
;  ! "
}!! 
catch"" 
("" 
	Exception"" 
)"" 
{## 
throw$$ 
;$$ 
}%% 
return&& 
result&& 
;&& 
}'' 	
public)) 
bool)) 
Delete)) 
<)) 
TEntity)) "
>))" #
())# $
TEntity))$ +
toDelete)), 4
)))4 5
where))6 ;
TEntity))< C
:))D E
class))F K
{** 	
bool++ 
result++ 
=++ 
false++ 
;++  
try,, 
{-- 

_dbContext// 
.// 
Entry//  
<//  !
TEntity//! (
>//( )
(//) *
toDelete//* 2
)//2 3
.//3 4
State//4 9
=//: ;
EntityState//< G
.//G H
Deleted//H O
;//O P
result22 
=22 

_dbContext22 #
.22# $
SaveChanges22$ /
(22/ 0
)220 1
>222 3
$num224 5
;225 6
}33 
catch44 
(44 
	Exception44 
)44 
{55 
throw66 
;66 
}77 
return88 
result88 
;88 
}99 	
public;; 
void;; 
Dispose;; 
(;; 
);; 
{<< 	
if== 
(== 

_dbContext== 
!=== 
null== "
)==" #
{>> 

_dbContext?? 
.?? 
Dispose?? "
(??" #
)??# $
;??$ %
}@@ 
}AA 	
publicCC 
ListCC 
<CC 
TEntityCC 
>CC 
FilterCC #
<CC# $
TEntityCC$ +
>CC+ ,
(CC, -

ExpressionCC- 7
<CC7 8
FuncCC8 <
<CC< =
TEntityCC= D
,CCD E
boolCCF J
>CCJ K
>CCK L
criteriaCCM U
)CCU V
whereCCW \
TEntityCC] d
:CCe f
classCCg l
{DD 	
ListEE 
<EE 
TEntityEE 
>EE 
resultEE  
=EE! "
nullEE# '
;EE' (
tryFF 
{GG 
resultHH 
=HH 

_dbContextHH #
.HH# $
SetHH$ '
<HH' (
TEntityHH( /
>HH/ 0
(HH0 1
)HH1 2
.HH2 3
WhereHH3 8
(HH8 9
criteriaHH9 A
)HHA B
.HHB C
ToListHHC I
(HHI J
)HHJ K
;HHK L
}JJ 
catchKK 
(KK 
	ExceptionKK 
)KK 
{LL 
throwMM 
;MM 
}NN 
returnOO 
resultOO 
;OO 
}QQ 	
publicSS 
TEntitySS 
RetrieveSS 
<SS  
TEntitySS  '
>SS' (
(SS( )

ExpressionSS) 3
<SS3 4
FuncSS4 8
<SS8 9
TEntitySS9 @
,SS@ A
boolSSB F
>SSF G
>SSG H
criteriaSSI Q
)SSQ R
whereSSS X
TEntitySSY `
:SSa b
classSSc h
{TT 	
TEntityUU 
resultUU 
=UU 
nullUU !
;UU! "
tryVV 
{WW 
resultXX 
=XX 

_dbContextXX #
.XX# $
SetXX$ '
<XX' (
TEntityXX( /
>XX/ 0
(XX0 1
)XX1 2
.XX2 3
FirstOrDefaultXX3 A
(XXA B
criteriaXXB J
)XXJ K
;XXK L
}ZZ 
catch[[ 
([[ 
	Exception[[ 
)[[ 
{\\ 
throw]] 
;]] 
}^^ 
return__ 
result__ 
;__ 
}`` 	
publicbb 
boolbb 
Updatebb 
<bb 
TEntitybb "
>bb" #
(bb# $
TEntitybb$ +
toUpdatebb, 4
)bb4 5
wherebb6 ;
TEntitybb< C
:bbD E
classbbF K
{cc 	
booldd 
resultdd 
=dd 
falsedd 
;dd  
tryee 
{ff 

_dbContexthh 
.hh 
Entryhh  
<hh  !
TEntityhh! (
>hh( )
(hh) *
toUpdatehh* 2
)hh2 3
.hh3 4
Statehh4 9
=hh: ;
EntityStatehh< G
.hhG H
ModifiedhhH P
;hhP Q
resultkk 
=kk 

_dbContextkk #
.kk# $
SaveChangeskk$ /
(kk/ 0
)kk0 1
>kk2 3
$numkk4 5
;kk5 6
}ll 
catchmm 
(mm 
	Exceptionmm 
)mm 
{nn 
throwoo 
;oo 
}pp 
returnqq 
resultqq 
;qq 
}rr 	
publicss 
Listss 
<ss 
TEntityss 
>ss 
GetAllss #
<ss# $
TEntityss$ +
>ss+ ,
(ss, -
)ss- .
wheress/ 4
TEntityss5 <
:ss= >
classss? D
{tt 	
returnuu 

_dbContextuu 
.uu 
Setuu !
<uu! "
TEntityuu" )
>uu) *
(uu* +
)uu+ ,
.uu, -
ToListuu- 3
(uu3 4
)uu4 5
;uu5 6
}vv 	
}xx 
}yy 