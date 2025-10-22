-- 2. INSERTAR TODAS LAS MARCAS

INSERT INTO MarcasCelular (Nombre, Descripcion, Activa, FechaCreacion) VALUES
('Apple', 'Empresa estadounidense líder en tecnología móvil, conocida por sus dispositivos iPhone con sistema iOS', 1, GETDATE()),
('Samsung', 'Empresa surcoreana líder en tecnología móvil, fabricante de dispositivos Galaxy con sistema Android', 1, GETDATE()),
('Motorola', 'Empresa estadounidense de telecomunicaciones, conocida por sus dispositivos Android con diseño premium', 1, GETDATE()),
('Xiaomi', 'Empresa china de tecnología móvil, conocida por ofrecer dispositivos de alta calidad a precios competitivos', 1, GETDATE());

-- 3. INSERTAR TODOS LOS MODELOS

-- Modelos de Apple (MarcaId = 1)
INSERT INTO ModelosCelular (Nombre, Descripcion, Precio, Disponible, FechaLanzamiento, MarcaId, FechaCreacion) VALUES
('iPhone 15 Pro', 'Smartphone premium de Apple con procesador A17 Pro y diseño en titanio', 4195800.00, 1, '2023-09-15', 1, GETDATE()),
('iPhone 16 Pro', 'Smartphone premium de Apple con procesador A18 Pro y cámara mejorada', 5035800.00, 1, '2024-09-15', 1, GETDATE()),
('iPhone 16 Pro Max', 'Smartphone premium de Apple con pantalla más grande y batería extendida', 5875800.00, 1, '2024-09-15', 1, GETDATE());

-- Modelos de Samsung (MarcaId = 2)
INSERT INTO ModelosCelular (Nombre, Descripcion, Precio, Disponible, FechaLanzamiento, MarcaId, FechaCreacion) VALUES
('Galaxy A56 5G', 'Smartphone de gama media de Samsung con conectividad 5G', 1999800.00, 1, '2024-03-15', 2, GETDATE()),
('Galaxy S24 Ultra 5G', 'Smartphone flagship de Samsung con S Pen y cámara de 200MP', 5455800.00, 1, '2024-01-17', 2, GETDATE()),
('Galaxy S25+ 5G', 'Smartphone premium de Samsung con pantalla Dynamic AMOLED', 4599800.00, 1, '2025-01-15', 2, GETDATE());

-- Modelos de Motorola (MarcaId = 3)
INSERT INTO ModelosCelular (Nombre, Descripcion, Precio, Disponible, FechaLanzamiento, MarcaId, FechaCreacion) VALUES
('Edge 50 Fusion', 'Smartphone premium de Motorola con pantalla pOLED curva', 1675800.00, 1, '2024-04-15', 3, GETDATE()),
('Moto G35', 'Smartphone de gama media de Motorola con Android puro', 899800.00, 1, '2024-02-15', 3, GETDATE()),
('Moto G75', 'Smartphone de gama media-alta de Motorola con características premium', 1299800.00, 1, '2024-06-15', 3, GETDATE());

-- Modelos de Xiaomi (MarcaId = 4)
INSERT INTO ModelosCelular (Nombre, Descripcion, Precio, Disponible, FechaLanzamiento, MarcaId, FechaCreacion) VALUES
('15T', 'Smartphone de gama media de Xiaomi con pantalla AMOLED 120Hz', 1675800.00, 1, '2024-09-15', 4, GETDATE()),
('15T Pro', 'Smartphone premium de Xiaomi con procesador MediaTek Dimensity', 1885800.00, 1, '2024-09-15', 4, GETDATE()),
('Redmi 15C', 'Smartphone de gama básica de Xiaomi con excelente relación calidad-precio', 799800.00, 1, '2024-11-15', 4, GETDATE());

-- 4. INSERTAR TODAS LAS CARACTERÍSTICAS

-- Características del iPhone 15 Pro (ModeloId = 1)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.1', 'pulgadas', 'Super Retina XDR OLED', 1, 1, 1, GETDATE()),
('Procesador', 'A17 Pro', 'chip', 'Procesador de 3nm', 2, 1, 1, GETDATE()),
('Almacenamiento', '128GB', 'GB', 'Opciones: 128GB, 256GB, 512GB, 1TB', 3, 1, 1, GETDATE()),
('RAM', '8', 'GB', 'Memoria RAM', 4, 1, 1, GETDATE()),
('Cámara Principal', '48', 'MP', 'Triple cámara con zoom óptico 3x', 5, 1, 1, GETDATE()),
('Batería', '23', 'horas', 'Reproducción de video', 6, 1, 1, GETDATE()),
('Resistencia al Agua', 'IP68', '', 'Resistente al agua y polvo', 7, 1, 1, GETDATE()),
('Sistema Operativo', 'iOS 17', '', 'Sistema operativo de Apple', 8, 1, 1, GETDATE()),
('Año', '2023', '', 'Año de lanzamiento', 9, 1, 1, GETDATE());

-- Características del iPhone 16 Pro (ModeloId = 2)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.3', 'pulgadas', 'Super Retina XDR OLED', 1, 1, 2, GETDATE()),
('Procesador', 'A18 Pro', 'chip', 'Procesador de 3nm mejorado', 2, 1, 2, GETDATE()),
('Almacenamiento', '256GB', 'GB', 'Opciones: 256GB, 512GB, 1TB', 3, 1, 2, GETDATE()),
('RAM', '8', 'GB', 'Memoria RAM', 4, 1, 2, GETDATE()),
('Cámara Principal', '48', 'MP', 'Cuádruple cámara con zoom óptico 5x', 5, 1, 2, GETDATE()),
('Batería', '25', 'horas', 'Reproducción de video', 6, 1, 2, GETDATE()),
('Resistencia al Agua', 'IP68', '', 'Resistente al agua y polvo', 7, 1, 2, GETDATE()),
('Sistema Operativo', 'iOS 18', '', 'Sistema operativo de Apple', 8, 1, 2, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 2, GETDATE());

-- Características del iPhone 16 Pro Max (ModeloId = 3)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.9', 'pulgadas', 'Super Retina XDR OLED', 1, 1, 3, GETDATE()),
('Procesador', 'A18 Pro', 'chip', 'Procesador de 3nm mejorado', 2, 1, 3, GETDATE()),
('Almacenamiento', '256GB', 'GB', 'Opciones: 256GB, 512GB, 1TB', 3, 1, 3, GETDATE()),
('RAM', '8', 'GB', 'Memoria RAM', 4, 1, 3, GETDATE()),
('Cámara Principal', '48', 'MP', 'Cuádruple cámara con zoom óptico 5x', 5, 1, 3, GETDATE()),
('Batería', '29', 'horas', 'Reproducción de video', 6, 1, 3, GETDATE()),
('Resistencia al Agua', 'IP68', '', 'Resistente al agua y polvo', 7, 1, 3, GETDATE()),
('Sistema Operativo', 'iOS 18', '', 'Sistema operativo de Apple', 8, 1, 3, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 3, GETDATE());

-- Características del Galaxy A56 5G (ModeloId = 4)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.6', 'pulgadas', 'Super AMOLED 120Hz', 1, 1, 4, GETDATE()),
('Procesador', 'Exynos 1480', 'chip', 'Procesador Samsung', 2, 1, 4, GETDATE()),
('Almacenamiento', '128GB', 'GB', 'Opciones: 128GB, 256GB', 3, 1, 4, GETDATE()),
('RAM', '8', 'GB', 'Memoria RAM', 4, 1, 4, GETDATE()),
('Cámara Principal', '50', 'MP', 'Triple cámara', 5, 1, 4, GETDATE()),
('Batería', '5000', 'mAh', 'Batería de larga duración', 6, 1, 4, GETDATE()),
('Resistencia al Agua', 'IP67', '', 'Resistente al agua', 7, 1, 4, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'One UI 6.1', 8, 1, 4, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 4, GETDATE());

-- Características del Galaxy S24 Ultra 5G (ModeloId = 5)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.8', 'pulgadas', 'Dynamic AMOLED 2X 120Hz', 1, 1, 5, GETDATE()),
('Procesador', 'Snapdragon 8 Gen 3', 'chip', 'Procesador Qualcomm', 2, 1, 5, GETDATE()),
('Almacenamiento', '256GB', 'GB', 'Opciones: 256GB, 512GB, 1TB', 3, 1, 5, GETDATE()),
('RAM', '12', 'GB', 'Memoria RAM', 4, 1, 5, GETDATE()),
('Cámara Principal', '200', 'MP', 'Cuádruple cámara con S Pen', 5, 1, 5, GETDATE()),
('Batería', '5000', 'mAh', 'Batería de larga duración', 6, 1, 5, GETDATE()),
('Resistencia al Agua', 'IP68', '', 'Resistente al agua y polvo', 7, 1, 5, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'One UI 6.1', 8, 1, 5, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 5, GETDATE());

-- Características del Galaxy S25+ 5G (ModeloId = 6)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.7', 'pulgadas', 'Dynamic AMOLED 2X 120Hz', 1, 1, 6, GETDATE()),
('Procesador', 'Snapdragon 8 Gen 4', 'chip', 'Procesador Qualcomm', 2, 1, 6, GETDATE()),
('Almacenamiento', '256GB', 'GB', 'Opciones: 256GB, 512GB', 3, 1, 6, GETDATE()),
('RAM', '12', 'GB', 'Memoria RAM', 4, 1, 6, GETDATE()),
('Cámara Principal', '50', 'MP', 'Triple cámara mejorada', 5, 1, 6, GETDATE()),
('Batería', '4900', 'mAh', 'Batería de larga duración', 6, 1, 6, GETDATE()),
('Resistencia al Agua', 'IP68', '', 'Resistente al agua y polvo', 7, 1, 6, GETDATE()),
('Sistema Operativo', 'Android 15', '', 'One UI 7.0', 8, 1, 6, GETDATE()),
('Año', '2025', '', 'Año de lanzamiento', 9, 1, 6, GETDATE());

-- Características del Edge 50 Fusion (ModeloId = 7)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.7', 'pulgadas', 'pOLED 144Hz curva', 1, 1, 7, GETDATE()),
('Procesador', 'Snapdragon 7s Gen 2', 'chip', 'Procesador Qualcomm', 2, 1, 7, GETDATE()),
('Almacenamiento', '128GB', 'GB', 'Opciones: 128GB, 256GB', 3, 1, 7, GETDATE()),
('RAM', '8', 'GB', 'Opciones: 8GB, 12GB', 4, 1, 7, GETDATE()),
('Cámara Principal', '50', 'MP', 'Dual cámara con OIS', 5, 1, 7, GETDATE()),
('Batería', '4400', 'mAh', 'Carga rápida 68W', 6, 1, 7, GETDATE()),
('Resistencia al Agua', 'IP68', '', 'Resistente al agua y polvo', 7, 1, 7, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'Android puro', 8, 1, 7, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 7, GETDATE());

-- Características del Moto G35 (ModeloId = 8)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.4', 'pulgadas', 'IPS LCD 90Hz', 1, 1, 8, GETDATE()),
('Procesador', 'Snapdragon 680', 'chip', 'Procesador Qualcomm', 2, 1, 8, GETDATE()),
('Almacenamiento', '128GB', 'GB', 'Almacenamiento interno', 3, 1, 8, GETDATE()),
('RAM', '6', 'GB', 'Memoria RAM', 4, 1, 8, GETDATE()),
('Cámara Principal', '50', 'MP', 'Triple cámara', 5, 1, 8, GETDATE()),
('Batería', '5000', 'mAh', 'Batería de larga duración', 6, 1, 8, GETDATE()),
('Resistencia al Agua', 'IP52', '', 'Resistente al agua', 7, 1, 8, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'Android puro', 8, 1, 8, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 8, GETDATE());

-- Características del Moto G75 (ModeloId = 9)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.6', 'pulgadas', 'IPS LCD 120Hz', 1, 1, 9, GETDATE()),
('Procesador', 'Snapdragon 732G', 'chip', 'Procesador Qualcomm', 2, 1, 9, GETDATE()),
('Almacenamiento', '128GB', 'GB', 'Almacenamiento interno', 3, 1, 9, GETDATE()),
('RAM', '8', 'GB', 'Memoria RAM', 4, 1, 9, GETDATE()),
('Cámara Principal', '64', 'MP', 'Triple cámara', 5, 1, 9, GETDATE()),
('Batería', '5000', 'mAh', 'Carga rápida 30W', 6, 1, 9, GETDATE()),
('Resistencia al Agua', 'IP52', '', 'Resistente al agua', 7, 1, 9, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'Android puro', 8, 1, 9, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 9, GETDATE());

-- Características del Xiaomi 15T (ModeloId = 10)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.67', 'pulgadas', 'AMOLED 120Hz', 1, 1, 10, GETDATE()),
('Procesador', 'MediaTek Dimensity 8200-Ultra', 'chip', 'Procesador MediaTek', 2, 1, 10, GETDATE()),
('Almacenamiento', '256GB', 'GB', 'Opciones: 256GB, 512GB', 3, 1, 10, GETDATE()),
('RAM', '8', 'GB', 'Opciones: 8GB, 12GB', 4, 1, 10, GETDATE()),
('Cámara Principal', '50', 'MP', 'Triple cámara', 5, 1, 10, GETDATE()),
('Batería', '5000', 'mAh', 'Carga rápida 67W', 6, 1, 10, GETDATE()),
('Resistencia al Agua', 'IP54', '', 'Resistente al agua', 7, 1, 10, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'MIUI 15', 8, 1, 10, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 10, GETDATE());

-- Características del Xiaomi 15T Pro (ModeloId = 11)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.67', 'pulgadas', 'AMOLED 120Hz', 1, 1, 11, GETDATE()),
('Procesador', 'MediaTek Dimensity 8300-Ultra', 'chip', 'Procesador MediaTek', 2, 1, 11, GETDATE()),
('Almacenamiento', '256GB', 'GB', 'Opciones: 256GB, 512GB', 3, 1, 11, GETDATE()),
('RAM', '12', 'GB', 'Memoria RAM', 4, 1, 11, GETDATE()),
('Cámara Principal', '50', 'MP', 'Triple cámara mejorada', 5, 1, 11, GETDATE()),
('Batería', '5000', 'mAh', 'Carga rápida 90W', 6, 1, 11, GETDATE()),
('Resistencia al Agua', 'IP54', '', 'Resistente al agua', 7, 1, 11, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'MIUI 15', 8, 1, 11, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 11, GETDATE());

-- Características del Redmi 15C (ModeloId = 12)
INSERT INTO CaracteristicasCelular (Nombre, Valor, Unidad, Descripcion, Orden, Activa, ModeloId, FechaCreacion) VALUES
('Pantalla', '6.71', 'pulgadas', 'IPS LCD 90Hz', 1, 1, 12, GETDATE()),
('Procesador', 'Snapdragon 685', 'chip', 'Procesador Qualcomm', 2, 1, 12, GETDATE()),
('Almacenamiento', '128GB', 'GB', 'Almacenamiento interno', 3, 1, 12, GETDATE()),
('RAM', '6', 'GB', 'Memoria RAM', 4, 1, 12, GETDATE()),
('Cámara Principal', '50', 'MP', 'Dual cámara', 5, 1, 12, GETDATE()),
('Batería', '5000', 'mAh', 'Carga rápida 18W', 6, 1, 12, GETDATE()),
('Resistencia al Agua', 'IP53', '', 'Resistente al agua', 7, 1, 12, GETDATE()),
('Sistema Operativo', 'Android 14', '', 'MIUI 15', 8, 1, 12, GETDATE()),
('Año', '2024', '', 'Año de lanzamiento', 9, 1, 12, GETDATE());
