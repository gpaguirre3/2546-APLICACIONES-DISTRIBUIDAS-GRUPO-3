¥-
JD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Program.cs
var 
builder 
= 
WebApplication 
. 
CreateBuilder *
(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
	AddScoped 
< 
Sales_DBEntities +
>+ ,
(, -
_- .
=>/ 1
{		 
var

 
connectionString

 
=

 
builder

 "
.

" #
Configuration

# 0
.

0 1
GetConnectionString

1 D
(

D E
$str

E W
)

W X
;

X Y
return 

new 
Sales_DBEntities 
(  
)  !
;! "
} 
) 
; 
builder 
. 
Services 
. 
AddControllers 
(  
)  !
. 
AddNewtonsoftJson 
( 
options 
=> !
{ 
options 
. 
SerializerSettings "
." #!
ReferenceLoopHandling# 8
=9 :

Newtonsoft; E
.E F
JsonF J
.J K!
ReferenceLoopHandlingK `
.` a
Ignorea g
;g h
options 
. 
SerializerSettings "
." #&
PreserveReferencesHandling# =
=> ?

Newtonsoft@ J
.J K
JsonK O
.O P&
PreserveReferencesHandlingP j
.j k
Nonek o
;o p
options 
. 
SerializerSettings "
." #
ContractResolver# 3
=4 5
new6 9

Newtonsoft: D
.D E
JsonE I
.I J
SerializationJ W
.W X#
DefaultContractResolverX o
(o p
)p q
;q r
} 
) 
; 
builder 
. 
Services 
. 
AddAuthentication "
(" #
JwtBearerDefaults# 4
.4 5 
AuthenticationScheme5 I
)I J
.J K
AddJwtBearerK W
(W X
optionsX _
=>` b
{ 
options 
.  
RequireHttpsMetadata  
=! "
false# (
;( )
options 
. 
	SaveToken 
= 
true 
; 
options 
. %
TokenValidationParameters %
=& '
new( +%
TokenValidationParameters, E
(E F
)F G
{ 
ValidateIssuer 
= 
true 
, 
ValidateAudience 
= 
true 
,  
ValidateLifetime 
= 
true 
,  $
ValidateIssuerSigningKey  
=! "
true# '
,' (
ValidAudience   
=   
builder   
.    
Configuration    -
[  - .
$str  . <
]  < =
,  = >
ValidIssuer!! 
=!! 
builder!! 
.!! 
Configuration!! +
[!!+ ,
$str!!, 8
]!!8 9
,!!9 :
IssuerSigningKey"" 
="" 
new""  
SymmetricSecurityKey"" 3
(""3 4
Encoding""4 <
.""< =
UTF8""= A
.""A B
GetBytes""B J
(""J K
builder""K R
.""R S
Configuration""S `
[""` a
$str""a j
]""j k
)""k l
)""l m
}## 
;## 
}$$ 
)$$ 
;$$ 
builder'' 
.'' 
Services'' 
.'' #
AddEndpointsApiExplorer'' (
(''( )
)'') *
;''* +
builder(( 
.(( 
Services(( 
.(( 
AddSwaggerGen(( 
((( 
)((  
;((  !
builder)) 
.)) 
Services)) 
.)) 
AddHttpClient)) 
()) 
)))  
;))  !
builder** 
.** 
Services** 
.** 
AddHttpClient** 
(** 
$str** )
,**) *
client**+ 1
=>**2 4
{++ 
client,, 

.,,
 
BaseAddress,, 
=,, 
new,, 
Uri,,  
(,,  !
$str,,! :
),,: ;
;,,; <
}-- 
)-- 
;-- 
var.. 
app.. 
=.. 	
builder..
 
... 
Build.. 
(.. 
).. 
;.. 
if00 
(00 
app00 
.00 
Environment00 
.00 
IsDevelopment00 !
(00! "
)00" #
)00# $
{11 
app22 
.22 

UseSwagger22 
(22 
)22 
;22 
app33 
.33 
UseSwaggerUI33 
(33 
)33 
;33 
}44 
app66 
.66 
UseHttpsRedirection66 
(66 
)66 
;66 
app77 
.77 
UseAuthentication77 
(77 
)77 
;77 
app88 
.88 
UseAuthorization88 
(88 
)88 
;88 
app99 
.99 
MapControllers99 
(99 
)99 
;99 
app:: 
.:: 
Run:: 
(:: 
):: 	
;::	 
¡	
SD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Models\UserModel.cs
	namespace 	
Security
 
. 
Models 
{ 
public 

class 
	UserModel 
{ 
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
EmailAddress "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
Rol 
{ 
get 
;  
set! $
;$ %
}& '
public		 
string		 
LastName		 
{		  
get		! $
;		$ %
set		& )
;		) *
}		+ ,
public

 
string

 
	FirstName

 
{

  !
get

" %
;

% &
set

' *
;

* +
}

, -
} 
} —
SD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Models\LoginUser.cs
	namespace 	
Security
 
. 
Models 
{ 
public 

class 
	LoginUser 
{ 
public 
string 
UserName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
} 
}		 —	
[D:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Controllers\RegisterUser.cs
	namespace 	
Security
 
. 
Controllers 
{ 
public 

class 
RegisterUser 
{ 
public 
string 
Username 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Password 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
Rol 
{ 
get 
;  
set! $
;$ %
}& '
public 
string 
EmailAddress "
{# $
get% (
;( )
set* -
;- .
}/ 0
public		 
string		 
	FirstName		 
{		  !
get		" %
;		% &
set		' *
;		* +
}		, -
public

 
string

 
LastName

 
{

  
get

! $
;

$ %
set

& )
;

) *
}

+ ,
} 
} ’=
`D:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Controllers\ProductController.cs
	namespace

 	
Security


 
.

 
Controllers

 
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
ProductController "
:# $
ControllerBase% 3
{ 
private 
readonly 

HttpClient #
_httpClient$ /
;/ 0
public 
ProductController  
(  !
IHttpClientFactory! 3
httpClientFactory4 E
)E F
{ 	
_httpClient 
= 
httpClientFactory +
.+ ,
CreateClient, 8
(8 9
$str9 C
)C D
;D E
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( 
Roles 
= 
$str 1
)1 2
]2 3
public 
async 
Task 
< 

ProductDTO $
>$ %
CreateProductDTO& 6
(6 7
[7 8
FromBody8 @
]@ A

ProductDTOB L
productM T
)T U
{ 	
var 
response 
= 
await  
_httpClient! ,
., -
PostAsJsonAsync- <
(< =
$str= [
,[ \
product] d
)d e
;e f
response 
. #
EnsureSuccessStatusCode ,
(, -
)- .
;. /
return   
await   
response   !
.  ! "
Content  " )
.  ) *
ReadFromJsonAsync  * ;
<  ; <

ProductDTO  < F
>  F G
(  G H
)  H I
;  I J
}!! 	
[$$ 	

HttpDelete$$	 
($$ 
$str$$ !
)$$! "
]$$" #
[%% 	
	Authorize%%	 
(%% 
Roles%% 
=%% 
$str%% *
)%%* +
]%%+ ,
public&& 
async&& 
Task&& 
<&& 
bool&& 
>&& 
Delete&&  &
(&&& '
int&&' *
id&&+ -
)&&- .
{'' 	
var(( 
response(( 
=(( 
await((  
_httpClient((! ,
.((, -
DeleteAsync((- 8
(((8 9
$"((9 ;
$str((; Q
{((Q R
id((R T
}((T U
"((U V
)((V W
;((W X
response)) 
.)) #
EnsureSuccessStatusCode)) ,
()), -
)))- .
;)). /
return** 
await** 
response** !
.**! "
Content**" )
.**) *
ReadFromJsonAsync*** ;
<**; <
bool**< @
>**@ A
(**A B
)**B C
;**C D
}++ 	
[.. 	
HttpGet..	 
(.. 
$str.. 
).. 
].. 
[// 	
	Authorize//	 
(// 
Roles// 
=// 
$str// 8
)//8 9
]//9 :
public00 
async00 
Task00 
<00 
List00 
<00 

ProductDTO00 )
>00) *
>00* +
FilterProducts00, :
(00: ;
[00; <
	FromQuery00< E
]00E F
string00G M
name00N R
)00R S
{11 	
var22 
response22 
=22 
await22  
_httpClient22! ,
.22, -
GetAsync22- 5
(225 6
$"226 8
$str228 X
{22X Y
name22Y ]
}22] ^
"22^ _
)22_ `
;22` a
response33 
.33 #
EnsureSuccessStatusCode33 ,
(33, -
)33- .
;33. /
return44 
await44 
response44 !
.44! "
Content44" )
.44) *
ReadFromJsonAsync44* ;
<44; <
List44< @
<44@ A

ProductDTO44A K
>44K L
>44L M
(44M N
)44N O
;44O P
}55 	
[88 	
HttpGet88	 
(88 
$str88 
)88  
]88  !
[99 	
	Authorize99	 
(99 
Roles99 
=99 
$str99 8
)998 9
]999 :
public:: 
async:: 
Task:: 
<:: 

ProductDTO:: $
>::$ %
GetProductById::& 4
(::4 5
int::5 8
id::9 ;
)::; <
{;; 	
var<< 
response<< 
=<< 
await<<  
_httpClient<<! ,
.<<, -
GetAsync<<- 5
(<<5 6
$"<<6 8
$str<<8 S
{<<S T
id<<T V
}<<V W
"<<W X
)<<X Y
;<<Y Z
response== 
.== #
EnsureSuccessStatusCode== ,
(==, -
)==- .
;==. /
return>> 
await>> 
response>> !
.>>! "
Content>>" )
.>>) *
ReadFromJsonAsync>>* ;
<>>; <

ProductDTO>>< F
>>>F G
(>>G H
)>>H I
;>>I J
}?? 	
[BB 	
HttpPutBB	 
(BB 
$strBB 
)BB 
]BB 
[CC 	
	AuthorizeCC	 
(CC 
RolesCC 
=CC 
$strCC 1
)CC1 2
]CC2 3
publicDD 
asyncDD 
TaskDD 
<DD 
boolDD 
>DD 
UpdateProductDTODD  0
(DD0 1
[DD1 2
FromBodyDD2 :
]DD: ;

ProductDTODD< F
productToUpdateDDG V
)DDV W
{EE 	
varFF 
responseFF 
=FF 
awaitFF  
_httpClientFF! ,
.FF, -
PutAsJsonAsyncFF- ;
(FF; <
$strFF< Z
,FFZ [
productToUpdateFF\ k
)FFk l
;FFl m
responseGG 
.GG #
EnsureSuccessStatusCodeGG ,
(GG, -
)GG- .
;GG. /
returnHH 
awaitHH 
responseHH !
.HH! "
ContentHH" )
.HH) *
ReadFromJsonAsyncHH* ;
<HH; <
boolHH< @
>HH@ A
(HHA B
)HHB C
;HHC D
}II 	
[LL 	
HttpGetLL	 
(LL 
$strLL (
)LL( )
]LL) *
[MM 	
	AuthorizeMM	 
(MM 
RolesMM 
=MM 
$strMM 8
)MM8 9
]MM9 :
publicNN 
asyncNN 
TaskNN 
<NN 
ListNN 
<NN 

ProductDTONN )
>NN) *
>NN* +)
FilterProductsDTOByCategoryIDNN, I
(NNI J
intNNJ M
idNNN P
)NNP Q
{OO 	
varPP 
responsePP 
=PP 
awaitPP  
_httpClientPP! ,
.PP, -
GetAsyncPP- 5
(PP5 6
$"PP6 8
$strPP8 e
{PPe f
idPPf h
}PPh i
"PPi j
)PPj k
;PPk l
responseQQ 
.QQ #
EnsureSuccessStatusCodeQQ ,
(QQ, -
)QQ- .
;QQ. /
returnRR 
awaitRR 
responseRR !
.RR! "
ContentRR" )
.RR) *
ReadFromJsonAsyncRR* ;
<RR; <
ListRR< @
<RR@ A

ProductDTORRA K
>RRK L
>RRL M
(RRM N
)RRN O
;RRO P
}SS 	
}TT 
}UU ¬T
^D:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Controllers\LoginController.cs
	namespace 	
Security
 
. 
Controllers 
{ 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
LoginController  
:! "
ControllerBase# 1
{ 
private 
readonly 
IConfiguration '
_config( /
;/ 0
public 
LoginController 
( 
IConfiguration -
config. 4
)4 5
{ 	
_config 
= 
config 
; 
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
IActionResult 
Login "
(" #
	LoginUser# ,
	userLogin- 6
)6 7
{ 	
var   
user   
=   
Authenticate   #
(  # $
	userLogin  $ -
)  - .
;  . /
if"" 
("" 
user"" 
!="" 
null"" 
)"" 
{## 
var%% 
token%% 
=%% 
Generate%% $
(%%$ %
user%%% )
)%%) *
;%%* +
return&& 
Ok&& 
(&& 
token&& 
)&&  
;&&  !
}'' 
return)) 
NotFound)) 
()) 
$str)) 3
)))3 4
;))4 5
}** 	
private-- 
	UserModel-- 
Authenticate-- &
(--& '
	LoginUser--' 0
	userLogin--1 :
)--: ;
{.. 	
	UserLogic// 
	userLogic// 
=//  
new//! $
	UserLogic//% .
(//. /
)/// 0
;//0 1
UserDTO00 
userDTO00 
=00 
	userLogic00 '
.00' (
Authenticate00( 4
(004 5
	userLogin005 >
.00> ?
UserName00? G
,00G H
	userLogin00I R
.00R S
Password00S [
)00[ \
;00\ ]
	UserModel11 
	userModel11 
=11  !
new11" %
	UserModel11& /
(11/ 0
)110 1
;111 2
if22 
(22 
userDTO22 
!=22 
null22 
)22 
{33 
	userModel44 
.44 
Username44 "
=44# $
userDTO44% ,
.44, -
Username44- 5
;445 6
	userModel55 
.55 
EmailAddress55 &
=55' (
userDTO55) 0
.550 1
EmailAddress551 =
;55= >
	userModel66 
.66 
Rol66 
=66 
userDTO66 %
.66% &
Rol66& )
;66) *
	userModel77 
.77 
	FirstName77 #
=77$ %
userDTO77& -
.77- .
	FirstName77. 7
;777 8
	userModel88 
.88 
LastName88 "
=88# $
userDTO88% ,
.88, -
LastName88- 5
;885 6
	userModel99 
.99 
Password99 "
=99# $
	userLogin99% .
.99. /
Password99/ 7
;997 8
return:: 
	userModel::  
;::  !
};; 
else<< 
{== 
return>> 
null>> 
;>> 
}?? 
}AA 	
privateEE 
stringEE 
GenerateEE 
(EE  
	UserModelEE  )
userEE* .
)EE. /
{FF 	
varGG 
securityKeyGG 
=GG 
newGG ! 
SymmetricSecurityKeyGG" 6
(GG6 7
EncodingGG7 ?
.GG? @
UTF8GG@ D
.GGD E
GetBytesGGE M
(GGM N
_configGGN U
[GGU V
$strGGV _
]GG_ `
)GG` a
)GGa b
;GGb c
varHH 
credentialsHH 
=HH 
newHH !
SigningCredentialsHH" 4
(HH4 5
securityKeyHH5 @
,HH@ A
SecurityAlgorithmsHHB T
.HHT U

HmacSha256HHU _
)HH_ `
;HH` a
varJJ 
claimsJJ 
=JJ 
newJJ 
[JJ 
]JJ 
{JJ  
newKK 
ClaimKK 
(KK 

ClaimTypesKK $
.KK$ %
NameIdentifierKK% 3
,KK3 4
userKK5 9
.KK9 :
UsernameKK: B
)KKB C
,KKC D
newLL 
ClaimLL 
(LL 

ClaimTypesLL $
.LL$ %
EmailLL% *
,LL* +
userLL, 0
.LL0 1
EmailAddressLL1 =
)LL= >
,LL> ?
newMM 
ClaimMM 
(MM 

ClaimTypesMM $
.MM$ %
	GivenNameMM% .
,MM. /
userMM0 4
.MM4 5
	FirstNameMM5 >
)MM> ?
,MM? @
newNN 
ClaimNN 
(NN 

ClaimTypesNN $
.NN$ %
SurnameNN% ,
,NN, -
userNN. 2
.NN2 3
LastNameNN3 ;
)NN; <
,NN< =
newOO 
ClaimOO 
(OO 

ClaimTypesOO $
.OO$ %
RoleOO% )
,OO) *
userOO+ /
.OO/ 0
RolOO0 3
)OO3 4
,OO4 5
}PP 
;PP 
varRR 
tokenRR 
=RR 
newRR 
JwtSecurityTokenRR ,
(RR, -
_configSS 
[SS 
$strSS $
]SS$ %
,SS% &
_configTT 
[TT 
$strTT &
]TT& '
,TT' (
claimsUU 
,UU 
expiresVV 
:VV 
DateTimeVV !
.VV! "
NowVV" %
.VV% &

AddMinutesVV& 0
(VV0 1
$numVV1 3
)VV3 4
,VV4 5
signingCredentialsWW "
:WW" #
credentialsWW$ /
)WW/ 0
;WW0 1
returnYY 
newYY #
JwtSecurityTokenHandlerYY .
(YY. /
)YY/ 0
.YY0 1

WriteTokenYY1 ;
(YY; <
tokenYY< A
)YYA B
;YYB C
}ZZ 	
[]] 	
HttpPost]]	 
(]] 
$str]] 
)]] 
]]] 
public^^ 
bool^^ 
Register^^ 
(^^ 
string^^ #
username^^$ ,
,^^, -
string^^. 4
password^^5 =
,^^= >
string^^? E
rol^^F I
,^^I J
string^^K Q
emailAddress^^R ^
,^^^ _
string^^` f
	firstName^^g p
,^^p q
string^^r x
lastName	^^y Å
)
^^Å Ç
{__ 	
Usersaa 
usersaa 
=aa 
newaa 
Usersaa #
(aa# $
)aa$ %
;aa% &
varbb 
	UserLogicbb 
=bb 
newbb 
	UserLogicbb  )
(bb) *
)bb* +
;bb+ ,
ifcc 
(cc 
	UserLogiccc 
.cc 
UsernameExistscc (
(cc( )
usernamecc) 1
)cc1 2
)cc2 3
{dd 
returnee 
falseee 
;ee 
}ff 
stringii 
hashedPasswordii !
=ii" #
BCryptii$ *
.ii* +
Netii+ .
.ii. /
BCryptii/ 5
.ii5 6
HashPasswordii6 B
(iiB C
passwordiiC K
)iiK L
;iiL M
usersjj 
.jj 
UserIdjj 
=jj 
$numjj 
;jj 
userskk 
.kk 
Usernamekk 
=kk 
usernamekk %
;kk% &
usersll 
.ll 
Passwordll 
=ll 
hashedPasswordll +
;ll+ ,
usersmm 
.mm 
EmailAddressmm 
=mm  
emailAddressmm! -
;mm- .
usersnn 
.nn 
	FirstNamenn 
=nn 
	firstNamenn '
;nn' (
usersoo 
.oo 
LastNameoo 
=oo 
lastNameoo %
;oo% &
userspp 
.pp 
Rolpp 
=pp 
rolpp 
;pp 
varss 
userss 
=ss 
	UserLogicss  
.ss  !
Createss! '
(ss' (
usersss( -
)ss- .
;ss. /
returntt 
truett 
;tt 
}uu 	
[xx 	
HttpGetxx	 
(xx 
$strxx  
)xx  !
]xx! "
publicyy 
IActionResultyy 
ObtenerCorreoyy *
(yy* +
stringyy+ 1
usernameyy2 :
)yy: ;
{zz 	
	UserLogic{{ 
	userLogic{{ 
={{  
new{{! $
	UserLogic{{% .
({{. /
){{/ 0
;{{0 1
var|| 
email|| 
=|| 
	userLogic|| !
.||! "
GetEmail||" *
(||* +
username||+ 3
)||3 4
;||4 5
if~~ 
(~~ 
email~~ 
!=~~ 
null~~ 
)~~ 
{ 
return
ÄÄ 
Ok
ÄÄ 
(
ÄÄ 
email
ÄÄ 
)
ÄÄ  
;
ÄÄ  !
}
ÅÅ 
return
ÉÉ 
NotFound
ÉÉ 
(
ÉÉ 
$str
ÉÉ 3
)
ÉÉ3 4
;
ÉÉ4 5
}
ÑÑ 	
[
ÜÜ 	
HttpPost
ÜÜ	 
(
ÜÜ 
$str
ÜÜ $
)
ÜÜ$ %
]
ÜÜ% &
public
áá 
IActionResult
áá 
VerificarUsuario
áá -
(
áá- .
string
áá. 4
username
áá5 =
)
áá= >
{
àà 	
	UserLogic
ââ 
	userLogic
ââ 
=
ââ  !
new
ââ" %
	UserLogic
ââ& /
(
ââ/ 0
)
ââ0 1
;
ââ1 2
bool
ãã 
usernameExists
ãã 
=
ãã  !
	userLogic
ãã" +
.
ãã+ ,
UsernameExists
ãã, :
(
ãã: ;
username
ãã; C
)
ããC D
;
ããD E
if
çç 
(
çç 
usernameExists
çç 
)
çç 
{
éé 
return
èè 
Conflict
èè 
(
èè  
$str
èè  A
)
èèA B
;
èèB C
}
êê 
else
ëë 
{
íí 
return
ìì 
Ok
ìì 
(
ìì 
$str
ìì A
)
ììA B
;
ììB C
}
îî 
}
ïï 	
}
öö 
}õõ À6
fD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Controllers\LoginAttemptsController.cs
	namespace

 	
Security


 
.

 
Controllers

 
{ 
[ 
Route 

(
 
$str 
) 
]  
[ 
ApiController 
] 
public 

class #
LoginAttemptsController (
:) *
ControllerBase+ 9
{ 
private 
readonly 

HttpClient #
_httpClient$ /
;/ 0
public #
LoginAttemptsController &
(& '
IHttpClientFactory' 9
httpClientFactory: K
)K L
{ 	
_httpClient 
= 
httpClientFactory +
.+ ,
CreateClient, 8
(8 9
$str9 C
)C D
;D E
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
public 
async 
Task 
< 
bool 
>  
RegisterLoginAttempt  4
(4 5
[5 6
FromBody6 >
]> ?
string@ F
usernameG O
)O P
{ 	
var 
response 
= 
await  
_httpClient! ,
., -
PostAsJsonAsync- <
(< =
$str= e
,e f
usernameg o
)o p
;p q
response 
. #
EnsureSuccessStatusCode ,
(, -
)- .
;. /
return 
await 
response !
.! "
Content" )
.) *
ReadFromJsonAsync* ;
<; <
bool< @
>@ A
(A B
)B C
;C D
}   	
[## 	
HttpGet##	 
(## 
$str## 
)## 
]## 
public%% 
async%% 
Task%% 
<%% 
bool%% 
>%% 
IsAccountBlocked%%  0
(%%0 1
[%%1 2
	FromQuery%%2 ;
]%%; <
string%%= C
username%%D L
)%%L M
{&& 	
var'' 
response'' 
='' 
await''  
_httpClient''! ,
.'', -
GetAsync''- 5
(''5 6
$"''6 8
$str''8 d
{''d e
username''e m
}''m n
"''n o
)''o p
;''p q
response(( 
.(( #
EnsureSuccessStatusCode(( ,
(((, -
)((- .
;((. /
return)) 
await)) 
response)) !
.))! "
Content))" )
.))) *
ReadFromJsonAsync))* ;
<)); <
bool))< @
>))@ A
())A B
)))B C
;))C D
}** 	
[-- 	
HttpPost--	 
(-- 
$str-- 
)-- 
]-- 
public// 
async// 
Task// 
<// 
bool// 
>// 
UnlockAccount//  -
(//- .
[//. /
FromBody/// 7
]//7 8
string//9 ?
username//@ H
)//H I
{00 	
var11 
response11 
=11 
await11  
_httpClient11! ,
.11, -
PostAsJsonAsync11- <
(11< =
$str11= ^
,11^ _
username11` h
)11h i
;11i j
response22 
.22 #
EnsureSuccessStatusCode22 ,
(22, -
)22- .
;22. /
return33 
await33 
response33 !
.33! "
Content33" )
.33) *
ReadFromJsonAsync33* ;
<33; <
bool33< @
>33@ A
(33A B
)33B C
;33C D
}44 	
[77 	
HttpPost77	 
(77 
$str77 
)77 
]77 
public99 
async99 
Task99 
<99 
bool99 
>99 
ResetLoginAttempts99  2
(992 3
[993 4
FromBody994 <
]99< =
string99> D
username99E M
)99M N
{:: 	
var;; 
response;; 
=;; 
await;;  
_httpClient;;! ,
.;;, -
PostAsJsonAsync;;- <
(;;< =
$str;;= c
,;;c d
username;;e m
);;m n
;;;n o
response<< 
.<< #
EnsureSuccessStatusCode<< ,
(<<, -
)<<- .
;<<. /
return== 
await== 
response== !
.==! "
Content==" )
.==) *
ReadFromJsonAsync==* ;
<==; <
bool==< @
>==@ A
(==A B
)==B C
;==C D
}>> 	
[AA 	
HttpGetAA	 
(AA 
$strAA 
)AA 
]AA 
publicCC 
asyncCC 
TaskCC 
<CC 
ListCC 
<CC 
LoginAttemptsCC ,
>CC, -
>CC- .
GetAllLoginAttemptsCC/ B
(CCB C
)CCC D
{DD 	
varEE 
responseEE 
=EE 
awaitEE  
_httpClientEE! ,
.EE, -
GetAsyncEE- 5
(EE5 6
$strEE6 ]
)EE] ^
;EE^ _
responseFF 
.FF #
EnsureSuccessStatusCodeFF ,
(FF, -
)FF- .
;FF. /
returnGG 
awaitGG 
responseGG !
.GG! "
ContentGG" )
.GG) *
ReadFromJsonAsyncGG* ;
<GG; <
ListGG< @
<GG@ A
LoginAttemptsGGA N
>GGN O
>GGO P
(GGP Q
)GGQ R
;GGR S
}HH 	
[KK 	
HttpGetKK	 
(KK 
$strKK 
)KK 
]KK 
publicMM 
asyncMM 
TaskMM 
<MM 
LoginAttemptsMM '
>MM' (+
RetrieveLoginAttemptsByUsernameMM) H
(MMH I
[MMI J
	FromQueryMMJ S
]MMS T
stringMMU [
usernameMM\ d
)MMd e
{NN 	
varOO 
responseOO 
=OO 
awaitOO  
_httpClientOO! ,
.OO, -
GetAsyncOO- 5
(OO5 6
$"OO6 8
$strOO8 s
{OOs t
usernameOOt |
}OO| }
"OO} ~
)OO~ 
;	OO Ä
responsePP 
.PP #
EnsureSuccessStatusCodePP ,
(PP, -
)PP- .
;PP. /
returnQQ 
awaitQQ 
responseQQ !
.QQ! "
ContentQQ" )
.QQ) *
ReadFromJsonAsyncQQ* ;
<QQ; <
LoginAttemptsQQ< I
>QQI J
(QQJ K
)QQK L
;QQL M
}RR 	
}SS 
}TT —;
aD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Controllers\CategoryController.cs
	namespace		 	
Security		
 
.		 
Controllers		 
{

 
[ 
Route 

(
 
$str 
) 
] 
[ 
ApiController 
] 
public 

class 
CategoryController #
:$ %
ControllerBase& 4
{ 
private 
readonly 

HttpClient #
_httpClient$ /
;/ 0
public 
CategoryController !
(! "
IHttpClientFactory" 4
httpClientFactory5 F
)F G
{ 	
_httpClient 
= 
httpClientFactory +
.+ ,
CreateClient, 8
(8 9
$str9 C
)C D
;D E
} 	
[ 	
HttpPost	 
( 
$str 
) 
] 
[ 	
	Authorize	 
( 
Roles 
= 
$str 1
)1 2
]2 3
public 
async 
Task 
< 
CategoryDTO %
>% &
	CreateDTO' 0
(0 1
CategoryDTO1 <
category= E
)E F
{ 	
var 
response 
= 
await  
_httpClient! ,
., -
PostAsJsonAsync- <
(< =
$str= U
,U V
categoryW _
)_ `
;` a
response 
. #
EnsureSuccessStatusCode ,
(, -
)- .
;. /
return 
await 
response !
.! "
Content" )
.) *
ReadFromJsonAsync* ;
<; <
CategoryDTO< G
>G H
(H I
)I J
;J K
} 	
[ 	

HttpDelete	 
( 
$str !
)! "
]" #
[   	
	Authorize  	 
(   
Roles   
=   
$str   *
)  * +
]  + ,
public!! 
async!! 
Task!! 
<!! 
bool!! 
>!! 
Delete!!  &
(!!& '
int!!' *
id!!+ -
)!!- .
{"" 	
var## 
response## 
=## 
await##  
_httpClient##! ,
.##, -
DeleteAsync##- 8
(##8 9
$"##9 ;
$str##; R
{##R S
id##S U
}##U V
"##V W
)##W X
;##X Y
response$$ 
.$$ #
EnsureSuccessStatusCode$$ ,
($$, -
)$$- .
;$$. /
return%% 
await%% 
response%% !
.%%! "
Content%%" )
.%%) *
ReadFromJsonAsync%%* ;
<%%; <
bool%%< @
>%%@ A
(%%A B
)%%B C
;%%C D
}&& 	
[(( 	
HttpGet((	 
((( 
$str(( 
)(( 
](( 
[)) 	
	Authorize))	 
()) 
Roles)) 
=)) 
$str)) 8
)))8 9
]))9 :
public** 
async** 
Task** 
<** 
List** 
<** 
CategoryDTO** *
>*** +
>**+ ,
	FilterDTO**- 6
(**6 7
string**7 =
name**> B
)**B C
{++ 	
var,, 
response,, 
=,, 
await,,  
_httpClient,,! ,
.,,, -
GetAsync,,- 5
(,,5 6
$",,6 8
$str,,8 T
{,,T U
name,,U Y
},,Y Z
",,Z [
),,[ \
;,,\ ]
response-- 
.-- #
EnsureSuccessStatusCode-- ,
(--, -
)--- .
;--. /
return.. 
await.. 
response.. !
...! "
Content.." )
...) *
ReadFromJsonAsync..* ;
<..; <
List..< @
<..@ A
CategoryDTO..A L
>..L M
>..M N
(..N O
)..O P
;..P Q
}// 	
[11 	
HttpGet11	 
(11 
$str11 
)11  
]11  !
[22 	
	Authorize22	 
(22 
Roles22 
=22 
$str22 8
)228 9
]229 :
public33 
async33 
Task33 
<33 
CategoryDTO33 %
>33% &
GetCategoryById33' 6
(336 7
int337 :
id33; =
)33= >
{44 	
var55 
response55 
=55 
await55  
_httpClient55! ,
.55, -
GetAsync55- 5
(555 6
$"556 8
$str558 X
{55X Y
id55Y [
}55[ \
"55\ ]
)55] ^
;55^ _
response66 
.66 #
EnsureSuccessStatusCode66 ,
(66, -
)66- .
;66. /
return77 
await77 
response77 !
.77! "
Content77" )
.77) *
ReadFromJsonAsync77* ;
<77; <
CategoryDTO77< G
>77G H
(77H I
)77I J
;77J K
}88 	
[:: 	
HttpPut::	 
(:: 
$str:: 
):: 
]:: 
[;; 	
	Authorize;;	 
(;; 
Roles;; 
=;; 
$str;; 1
);;1 2
];;2 3
public<< 
async<< 
Task<< 
<<< 
bool<< 
><< 
	UpdateDTO<<  )
(<<) *
CategoryDTO<<* 5
categoryToUpdate<<6 F
)<<F G
{== 	
var>> 
response>> 
=>> 
await>>  
_httpClient>>! ,
.>>, -
PutAsJsonAsync>>- ;
(>>; <
$str>>< T
,>>T U
categoryToUpdate>>V f
)>>f g
;>>g h
response?? 
.?? #
EnsureSuccessStatusCode?? ,
(??, -
)??- .
;??. /
return@@ 
await@@ 
response@@ !
.@@! "
Content@@" )
.@@) *
ReadFromJsonAsync@@* ;
<@@; <
bool@@< @
>@@@ A
(@@A B
)@@B C
;@@C D
}AA 	
[CC 	
HttpGetCC	 
(CC 
$strCC 
)CC 
]CC 
[DD 	
	AuthorizeDD	 
(DD 
RolesDD 
=DD 
$strDD 8
)DD8 9
]DD9 :
publicEE 
asyncEE 
TaskEE 
<EE 
ListEE 
<EE 
CategoryDTOEE *
>EE* +
>EE+ ,
GetAllEE- 3
(EE3 4
)EE4 5
{FF 	
varGG 
responseGG 
=GG 
awaitGG  
_httpClientGG! ,
.GG, -
GetAsyncGG- 5
(GG5 6
$"GG6 8
$strGG8 K
"GGK L
)GGL M
;GGM N
responseHH 
.HH #
EnsureSuccessStatusCodeHH ,
(HH, -
)HH- .
;HH. /
returnII 
awaitII 
responseII !
.II! "
ContentII" )
.II) *
ReadFromJsonAsyncII* ;
<II; <
ListII< @
<II@ A
CategoryDTOIIA L
>IIL M
>IIM N
(IIN O
)IIO P
;IIP Q
}JJ 	
}KK 
}LL Æ
ZD:\ESCRITORIO\septimo\distribuidas\proyecto\Sales_2026\Security\Constants\UserConstants.cs
	namespace 	
Security
 
. 
	Constants 
{ 
public 

class 
UserConstants 
{ 
public 
static 
List 
< 
	UserModel $
>$ %
Users& +
=, -
new. 1
List2 6
<6 7
	UserModel7 @
>@ A
(A B
)B C
{ 	
new		 
	UserModel		 
(		 
)		 
{		 
Username		 &
=		' (
$str		) 1
,		1 2
Password		3 ;
=		< =
$str		> H
,		H I
Rol		J M
=		N O
$str		P _
,		_ `
EmailAddress		a m
=		n o
$str			p Ç
,
		Ç É
	FirstName
		Ñ ç
=
		é è
$str
		ê ñ
,
		ñ ó
LastName
		ò †
=
		° ¢
$str
		£ ™
}
		™ ´
,
		´ ¨
new

 
	UserModel

 
(

 
)

 
{

 
Username

 &
=

' (
$str

) 4
,

4 5
Password

6 >
=

? @
$str

A K
,

K L
Rol

M P
=

Q R
$str

S [
,

[ \
EmailAddress

] i
=

j k
$str	

l Å
,


Å Ç
	FirstName


É å
=


ç é
$str


è ñ
,


ñ ó
LastName


ò †
=


° ¢
$str


£ ≠
}


≠ Æ
,


Æ Ø
new 
	UserModel 
( 
) 
{ 
Username &
=' (
$str) 0
,0 1
Password2 :
=; <
$str= G
,G H
RolI L
=M N
$strO W
,W X
EmailAddressY e
=f g
$strh }
,} ~
	FirstName	 à
=
â ä
$str
ã í
,
í ì
LastName
î ú
=
ù û
$str
ü ©
}
© ™
,
™ ´
} 	
;	 

} 
} 