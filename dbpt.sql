-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 27/05/2023 às 00:23
-- Versão do servidor: 10.4.28-MariaDB
-- Versão do PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `dbpt`
--

-- --------------------------------------------------------

--
-- Estrutura para tabela `aluno`
--

CREATE TABLE `aluno` (
    `ID` INT NOT NULL AUTO_INCREMENT,
	`nome` VARCHAR(255) NOT NULL,
	`telefone` INT,
	`data_nascimento` VARCHAR(255) NOT NULL,
	`altura` FLOAT,
	`IDs_fichas` VARCHAR(100),
	PRIMARY KEY (ID)  
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `ficha`
--

CREATE TABLE `ficha` (
	`ID` INT NOT NULL AUTO_INCREMENT,
	`ID_aluno` INT,
	`data` VARCHAR(255) NOT NULL,
	`peso` FLOAT,
	`medida_barriga` FLOAT,
	`medida_peito` FLOAT,
	`medida_braco_direito` FLOAT,
	`medida_braco_esquerdo` FLOAT,
	`medida_perna_direita` FLOAT,
	`medida_perna_esquerda` FLOAT,
	`comentarios` VARCHAR(255) NOT NULL,
	PRIMARY KEY (ID)                                
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuario`
--

CREATE TABLE `usuario` (
	`ID` INT NOT NULL AUTO_INCREMENT,
	`nome` VARCHAR(255) NOT NULL,
	`email` VARCHAR(255) NOT NULL,
	`senha` VARCHAR(255) NOT NULL,
	PRIMARY KEY (ID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usuario`
--


--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `aluno`
--


--
-- Índices de tabela `ficha`
--


--
-- Índices de tabela `usuario`
--


--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `aluno`
--
ALTER TABLE `aluno`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `ficha`
--
ALTER TABLE `ficha`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
