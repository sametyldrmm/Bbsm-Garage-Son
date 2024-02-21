SELECT ce.*, cte.* FROM "CardEntity" ce LEFT JOIN
 "CardTwoStageEntity" cte ON "ce"."Id" = "cte"."CardEntityId";
