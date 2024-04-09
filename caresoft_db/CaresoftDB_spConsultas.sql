-- STORED PROCEDURES RELACIONADOS A LAS CONSULTAS

-- 1. Creación de consulta
DROP PROCEDURE IF EXISTS spConsultaCrear;
DELIMITER //
CREATE PROCEDURE spConsultaCrear(
    IN p_consultaCodigo VARCHAR(30),
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_idConsultorio INT UNSIGNED,
    IN p_motivo NVARCHAR(255),
    IN p_comentarios TEXT,
    IN p_costo DECIMAL(10,2),
    IN p_estado ENUM('P', 'R')  -- Estado de la consulta
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    -- Verificar si el paciente y el médico existen
    SELECT COUNT(*) INTO @pacienteExiste FROM PerfilUsuario WHERE documento = p_documentoPaciente;
    SELECT COUNT(*) INTO @medicoExiste FROM PerfilUsuario WHERE documento = p_documentoMedico;

    IF @pacienteExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El paciente especificado no existe';
    END IF;

    IF @medicoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico especificado no existe';
    END IF;

    -- Crear la nueva consulta
    INSERT INTO Consulta (consultaCodigo, documentoPaciente, documentoMedico, idConsultorio, motivo, comentarios, costo, estado)
    VALUES (p_consultaCodigo, p_documentoPaciente, p_documentoMedico, p_idConsultorio, p_motivo, p_comentarios, p_costo, p_estado);

    COMMIT;
END //
DELIMITER ;

-- 2. Actualización de los datos de una consulta
DROP PROCEDURE IF EXISTS spConsultaActualizar;
DELIMITER //
CREATE PROCEDURE spConsultaActualizar(
    IN p_consultaCodigo VARCHAR(30),
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_idConsultorio INT UNSIGNED,
    IN p_motivo NVARCHAR(255),
    IN p_comentarios TEXT,
    IN p_costo DECIMAL(10,2)
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;
    
    -- Verificar si la consulta existe
    SELECT COUNT(*) INTO @consultaExiste FROM Consulta WHERE consultaCodigo = p_consultaCodigo;
    
    IF @consultaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La consulta especificada no existe';
    END IF;

    -- Verificar si el paciente y el médico existen
    SELECT COUNT(*) INTO @pacienteExiste FROM PerfilUsuario WHERE documento = p_documentoPaciente;
    SELECT COUNT(*) INTO @medicoExiste FROM PerfilUsuario WHERE documento = p_documentoMedico;
    
    IF @pacienteExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El paciente especificado no existe';
    END IF;
    
    IF @medicoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico especificado no existe';
    END IF;

    -- Actualizar los datos de la consulta
    UPDATE Consulta
    SET documentoPaciente = p_documentoPaciente,
        documentoMedico = p_documentoMedico,
        idConsultorio = p_idConsultorio,
        motivo = p_motivo,
        comentarios = p_comentarios,
        costo = p_costo
    WHERE consultaCodigo = p_consultaCodigo;

    COMMIT;
END //
DELIMITER ;

-- 3. Eliminación de una consulta
DROP PROCEDURE IF EXISTS spConsultaEliminar;
DELIMITER //
CREATE PROCEDURE spConsultaEliminar(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    DELETE FROM Consulta WHERE consultaCodigo = p_consultaCodigo;

    COMMIT;
END //
DELIMITER ;

-- 4. Prescribir un servicio en una consulta
DROP PROCEDURE IF EXISTS spConsultaPrescribirServicio;
DELIMITER //
CREATE PROCEDURE spConsultaPrescribirServicio(
    IN p_consultaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    -- Verificar si la consulta y el servicio existen
    SELECT COUNT(*) INTO @consultaExiste FROM Consulta WHERE consultaCodigo = p_consultaCodigo;
    SELECT COUNT(*) INTO @servicioExiste FROM Servicio WHERE servicioCodigo = p_servicioCodigo;

    IF @consultaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La consulta especificada no existe';
    END IF;

    IF @servicioExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El servicio especificado no existe';
    END IF;

    -- Prescribir el servicio en la consulta
    INSERT INTO PrescripcionServicio (consultaCodigo, servicioCodigo) VALUES (p_consultaCodigo, p_servicioCodigo);

    COMMIT;
END //
DELIMITER ;

-- 5. Prescribir un producto en una consulta
DROP PROCEDURE IF EXISTS spConsultaPrescribirProducto;
DELIMITER //
CREATE PROCEDURE spConsultaPrescribirProducto(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_cantidad INT
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    -- Verificar si la consulta y el producto existen
    SELECT COUNT(*) INTO @consultaExiste FROM Consulta WHERE consultaCodigo = p_consultaCodigo;
    SELECT COUNT(*) INTO @productoExiste FROM Producto WHERE idProducto = p_idProducto;

    IF @consultaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La consulta especificada no existe';
    END IF;

    IF @productoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El producto especificado no existe';
    END IF;

    -- Prescribir el producto en la consulta
    INSERT INTO PrescripcionProducto (consultaCodigo, idProducto, cantidad) VALUES (p_consultaCodigo, p_idProducto, p_cantidad);

    COMMIT;
END //
DELIMITER ;

-- 6. Registrar una afección tratada en una consulta
DROP PROCEDURE IF EXISTS spConsultaInsertarAfeccion;
DELIMITER //
CREATE PROCEDURE spConsultaInsertarAfeccion(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    -- Verificar si la consulta y la afección existen
    SELECT COUNT(*) INTO @consultaExiste FROM Consulta WHERE consultaCodigo = p_consultaCodigo;
    SELECT COUNT(*) INTO @afeccionExiste FROM Afeccion WHERE idAfeccion = p_idAfeccion;

    IF @consultaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La consulta especificada no existe';
    END IF;

    IF @afeccionExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La afección especificada no existe';
    END IF;

    -- Registrar la afección tratada en la consulta
    INSERT INTO ConsultaAfeccion (consultaCodigo, idAfeccion) VALUES (p_consultaCodigo, p_idAfeccion);

    COMMIT;
END //
DELIMITER ;

-- 7. Listar consultas con filtros opcionales
DROP PROCEDURE IF EXISTS spListarConsultas;
DELIMITER //
CREATE PROCEDURE spListarConsultas(
    IN p_documentoPaciente VARCHAR(30) NULL,
    IN p_documentoMedico VARCHAR(30) NULL,
    IN p_fechaInicio DATETIME NULL,
    IN p_fechaFin DATETIME NULL
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoPaciente IS NULL AND p_documentoMedico IS NULL AND p_fechaInicio IS NULL AND p_fechaFin IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las consultas
        SELECT *
        FROM Consulta;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Consulta WHERE 1 = 1';
        
        IF p_documentoPaciente IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoPaciente = "', p_documentoPaciente, '"');
        END IF;
        
        IF p_documentoMedico IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoMedico = "', p_documentoMedico, '"');
        END IF;
        
        IF p_fechaInicio IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha >= "', p_fechaInicio, '"');
        END IF;
        
        IF p_fechaFin IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha <= "', p_fechaFin, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;
