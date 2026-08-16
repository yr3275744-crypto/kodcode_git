 SELECT `p`.`Id`, `p`.`AuthorId`, `p`.`Title`, `p`.`Body`, `a`.`Id`, `a`.`FullName`, `a`.`Email`, `a`.`JoinedDate`, `c`.`Id`, `c`.`CommenterName`, `c`.`CreatedAt`, `c`.`PostId`, `c`.`Text`
      FROM `Posts` AS `p`
      INNER JOIN `Authors` AS `a` ON `p`.`AuthorId` = `a`.`Id`
      LEFT JOIN `Comments` AS `c` ON `p`.`Id` = `c`.`PostId`
      ORDER BY `p`.`Id`, `a`.`Id`

SELECT `p`.`Id`, `p`.`AuthorId`, `p`.`Title`, `p`.`Body`, `a`.`Id`, `a`.`FullName`, `a`.`Email`, `a`.`JoinedDate`, `c`.`Id`, `c`.`CommenterName`, `c`.`CreatedAt`, `c`.`PostId`, `c`.`Text`
      FROM `Posts` AS `p`
      INNER JOIN `Authors` AS `a` ON `p`.`AuthorId` = `a`.`Id`
      LEFT JOIN `Comments` AS `c` ON `p`.`Id` = `c`.`PostId`
      WHERE ((p.IsPublished AND (`p`.`AuthorId` = 1)) AND (`p`.`PublishedDate` >= 2023-01-15T00:00:00)) AND (`p`.`PublishedDate` <= 2024-04-24T16:20:00)
      ORDER BY p.Id, a.Id