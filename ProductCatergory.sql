select p."Name" as "ProductName", c."Name" as "CategoryName"
from "Product" p 
left join "ProductCatergory" pc on pc."ProductId" = p."Id" 
left join "Catergory" c on c."Id" = pc."CatergoryId"