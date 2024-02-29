-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: school
-- ------------------------------------------------------
-- Server version	8.0.35

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `кабинет`
--

DROP TABLE IF EXISTS `кабинет`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `кабинет` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Наименование` varchar(20) NOT NULL,
  `Этаж` int NOT NULL,
  `Паспорт_кабинета` varchar(20) NOT NULL,
  PRIMARY KEY (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `кабинет`
--

LOCK TABLES `кабинет` WRITE;
/*!40000 ALTER TABLE `кабинет` DISABLE KEYS */;
INSERT INTO `кабинет` VALUES (1,'Кабинет 1',1,'Аттестован'),(2,'Кабинет 2',2,'Аттестован');
/*!40000 ALTER TABLE `кабинет` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `класс`
--

DROP TABLE IF EXISTS `класс`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `класс` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Название` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `класс`
--

LOCK TABLES `класс` WRITE;
/*!40000 ALTER TABLE `класс` DISABLE KEYS */;
INSERT INTO `класс` VALUES (1,'1А'),(2,'1Б');
/*!40000 ALTER TABLE `класс` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `кружки`
--

DROP TABLE IF EXISTS `кружки`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `кружки` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Название` varchar(20) NOT NULL,
  `Код_учителя` int NOT NULL,
  ` Кол_учеников` int DEFAULT NULL,
  `Время` varchar(20) DEFAULT NULL,
  `Дни_недели` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Код`),
  KEY `Кружки_учителя_Код_fk` (`Код_учителя`),
  CONSTRAINT `Кружки_учителя_Код_fk` FOREIGN KEY (`Код_учителя`) REFERENCES `учителя` (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `кружки`
--

LOCK TABLES `кружки` WRITE;
/*!40000 ALTER TABLE `кружки` DISABLE KEYS */;
INSERT INTO `кружки` VALUES (1,'Футбол',2,12,'16:00','Среда'),(2,'Пионербол',2,12,'15:30','Пятница'),(3,'Рисование',1,4,'15:00','Вторник'),(4,'Чтение',3,5,'17:00','Понедельник'),(5,'Умелые_руки',1,7,'16:30','Четверг');
/*!40000 ALTER TABLE `кружки` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `недельное_расписание_уроков`
--

DROP TABLE IF EXISTS `недельное_расписание_уроков`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `недельное_расписание_уроков` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Код_урока` int NOT NULL,
  `Понедельник` varchar(20) DEFAULT NULL,
  `Вторник` varchar(20) DEFAULT NULL,
  `Среда` varchar(20) DEFAULT NULL,
  `Четверг` varchar(20) DEFAULT NULL,
  `Пятница` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`Код`),
  KEY `Недельное_расписание_уроков_урок_Код_fk` (`Код_урока`),
  CONSTRAINT `Недельное_расписание_уроков_урок_Код_fk` FOREIGN KEY (`Код_урока`) REFERENCES `урок` (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `недельное_расписание_уроков`
--

LOCK TABLES `недельное_расписание_уроков` WRITE;
/*!40000 ALTER TABLE `недельное_расписание_уроков` DISABLE KEYS */;
INSERT INTO `недельное_расписание_уроков` VALUES (1,1,'8:55-9:40','8:00-8:45','9:50-10:35','9:50-10:35','8:00-8:45'),(2,4,'8:00-8:45','8:55-9:40','8:00-8:45','8:55-9:40','8:55-9:40'),(3,5,'9:50-10:35','9:50-10:35','8:55-9:40','8:00-8:45','9:50-10:35'),(4,2,'8:00-8:45','8:55-9:40','8:00-8:45','8:00-8:45','8:55-9:40'),(5,3,'9:50-10:35','9:50-10:35','8:55-9:40','9:50-10:35','9:50-10:35'),(6,6,'8:55-9:40','8:00-8:45','9:50-10:35','8:55-9:40','8:00-8:45');
/*!40000 ALTER TABLE `недельное_расписание_уроков` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `предмет`
--

DROP TABLE IF EXISTS `предмет`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `предмет` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Название` varchar(20) NOT NULL,
  PRIMARY KEY (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `предмет`
--

LOCK TABLES `предмет` WRITE;
/*!40000 ALTER TABLE `предмет` DISABLE KEYS */;
INSERT INTO `предмет` VALUES (1,'Математика'),(2,'Русский_язык'),(3,'Литература');
/*!40000 ALTER TABLE `предмет` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `урок`
--

DROP TABLE IF EXISTS `урок`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `урок` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Название` varchar(20) NOT NULL,
  `Код_учителя` int NOT NULL,
  `Код_класса` int NOT NULL,
  PRIMARY KEY (`Код`),
  KEY `Урок_класс_Код_fk` (`Код_класса`),
  KEY `Урок_учителя_Код_fk` (`Код_учителя`),
  CONSTRAINT `Урок_класс_Код_fk` FOREIGN KEY (`Код_класса`) REFERENCES `класс` (`Код`),
  CONSTRAINT `Урок_учителя_Код_fk` FOREIGN KEY (`Код_учителя`) REFERENCES `учителя` (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `урок`
--

LOCK TABLES `урок` WRITE;
/*!40000 ALTER TABLE `урок` DISABLE KEYS */;
INSERT INTO `урок` VALUES (1,'Математика',2,1),(2,'Математика',2,2),(3,'Русский_язык',1,2),(4,'Русский_язык',1,1),(5,'Литература',3,1),(6,'Литература',3,2);
/*!40000 ALTER TABLE `урок` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ученик`
--

DROP TABLE IF EXISTS `ученик`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ученик` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Фамилия` varchar(20) NOT NULL,
  `Имя` varchar(20) NOT NULL,
  `Отчество` varchar(20) NOT NULL,
  `Дата_рождения` varchar(20) NOT NULL,
  `Код_класса` int NOT NULL,
  PRIMARY KEY (`Код`),
  KEY `Ученик_класс_Код_fk` (`Код_класса`),
  CONSTRAINT `Ученик_класс_Код_fk` FOREIGN KEY (`Код_класса`) REFERENCES `класс` (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ученик`
--

LOCK TABLES `ученик` WRITE;
/*!40000 ALTER TABLE `ученик` DISABLE KEYS */;
INSERT INTO `ученик` VALUES (1,'Иванов','Иван','Иванович','12.12.2017',2),(2,'Петров','Максим','Сергеевич','07.10.2017',2),(3,'Киселева','Вероника','Александровна','16.02.2017',1),(4,'Игнатова','Алиса','Михайловна','10.10.2017',2),(5,'Новиков','Дмитрий','Игорович','15.11.2017',1),(6,'Павлова','Полина','Дмитревна','14.10.2017',1),(7,'Ершова','Мария','Савельева','26.11.2017',1),(8,'Белов','Родион','Егорович','20.01.2017',2),(9,'Хромова','Амина','Игорова','18.03.2017',1),(10,'Николаев','Даниил','Маркович','27.12.2016',2),(11,'Ткачев','Константин','Мирославович','22.12.2016',2),(12,'Горячева','Ева','Кириллова','13.04.2017',2),(13,'Флоров','Алесандр','Егорович','14.05.2017',1),(14,'Герасимов','Григорий','Максимович','18.06.2017',1),(15,'Никулин','Максим','Николаевич','11.11.2016',2),(16,'Нивиков','Александр','Игорович','15.11.2017',1);
/*!40000 ALTER TABLE `ученик` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `учителя`
--

DROP TABLE IF EXISTS `учителя`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `учителя` (
  `Код` int NOT NULL AUTO_INCREMENT,
  `Фамилия` varchar(20) NOT NULL,
  `Имя` varchar(20) NOT NULL,
  `Отчество` varchar(20) NOT NULL,
  `Стаж_работы` int DEFAULT NULL,
  `Классное_руководство` varchar(20) DEFAULT NULL,
  `Код_кабинет` int NOT NULL,
  `Код_предмета` int NOT NULL,
  PRIMARY KEY (`Код`),
  KEY `Учителя_кабинет_Код_fk` (`Код_кабинет`),
  KEY `Учителя_предмет_Код_fk` (`Код_предмета`),
  CONSTRAINT `Учителя_кабинет_Код_fk` FOREIGN KEY (`Код_кабинет`) REFERENCES `кабинет` (`Код`),
  CONSTRAINT `Учителя_предмет_Код_fk` FOREIGN KEY (`Код_предмета`) REFERENCES `предмет` (`Код`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `учителя`
--

LOCK TABLES `учителя` WRITE;
/*!40000 ALTER TABLE `учителя` DISABLE KEYS */;
INSERT INTO `учителя` VALUES (1,'Розанова ','София ','Сергеевна',12,'Да',1,2),(2,'Петров','Сергей','Максимович',3,'Нет',2,1),(3,'Игнатова','Алиса','Михайловна',20,'Да',1,3);
/*!40000 ALTER TABLE `учителя` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-02-29 20:33:41
