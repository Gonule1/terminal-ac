BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Users" (
	"kullaniciadi"	TEXT NOT NULL,
	"sifre"	TEXT NOT NULL,
	"adSoyad"	TEXT NOT NULL,
	"id"	INTEGER,
	PRIMARY KEY("kullaniciadi")
);
INSERT INTO "Users" ("kullaniciadi","sifre","adSoyad","id") VALUES ('gonull','123456','gönül',NULL);
INSERT INTO "Users" ("kullaniciadi","sifre","adSoyad","id") VALUES ('ayse33','456789','ayse',NULL);
INSERT INTO "Users" ("kullaniciadi","sifre","adSoyad","id") VALUES ('aylin311','aylin123','aylin',NULL);
COMMIT;
