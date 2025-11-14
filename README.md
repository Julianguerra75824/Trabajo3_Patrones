# Patrones de Comportamiento en C# — Strategy y Observer  
Este proyecto demuestra la implementación de dos patrones de comportamiento del GoF (Gang of Four) aplicados a escenarios reales:

- **Strategy** → para el cálculo de precios con políticas intercambiables.  
- **Observer** → para la gestión de notificaciones desacopladas mediante eventos.

---

## 🧩 Patrones Implementados

### 1. Strategy — Cálculo dinámico de precios

**Problema:**  
Un sistema de ventas necesita calcular el precio final de un pedido aplicando distintas políticas:  
precio regular, descuentos promocionales, impuestos regionales, etc.

**Solución (Patrón Strategy):**  
Encapsular cada política de cálculo en su propia estrategia intercambiable.  
El contexto (`PricingContext`) permite cambiar la estrategia en tiempo de ejecución sin modificar el código del pedido.

**Beneficios:**
- Cumple el principio Open/Closed (OCP).  
- Permite probar, extender y combinar políticas fácilmente.  
- Reduce lógica condicional compleja.

---

### 2. Observer — Sistema de notificaciones

**Problema:**  
Cuando ocurre un evento (pedido creado, inventario bajo), múltiples componentes deben reaccionar (email, SMS, logs…), sin que el emisor conozca a los receptores.

**Solución (Patrón Observer):**  
El sujeto (`NotificationCenter`) notifica a todos los subscriptores registrados.  
Los observadores se pueden añadir o quitar en tiempo de ejecución.

**Beneficios:**
- Desacoplamiento total entre el emisor y los receptores.  
- Sistema extensible: agregar nuevos notificaciones sin modificar código existente.  
- Estructura ideal para eventos de dominio.

---

## 🗂️ Estructura del Proyecto

PatronesComportamiento
Program.cs
**Strategy**
  -Models.cs
  -IPricingStrategy.cs
  -RegularPricingStrategy.cs
  -DiscountPricingStrategy.cs
  -TaxInclusivePricingStrategy.cs
**Observer**
  -Events.cs
  -ISubscriber.cs
  -NotificationCenter.cs
  -EmailSubscriber.cs
  -SmsSubscriber.cs
  -LoggerSubscriber.cs
