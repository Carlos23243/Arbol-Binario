class ArbolBinario {
    public Nodo Raiz;

    public ArbolBinario() => Raiz = null;

    // --- Inserción ---
    public void Insertar(int valor) => Raiz = InsertarRecursivo(Raiz, valor);

    private Nodo InsertarRecursivo(Nodo raiz, int valor) 
    {
        if (raiz == null) return new Nodo(valor);
        if (valor < raiz.Valor) raiz.Izquierdo = InsertarRecursivo(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor) raiz.Derecho = InsertarRecursivo(raiz.Derecho, valor);
        return raiz;
    }

    // --- Búsqueda ---
    public bool Buscar(int valor) => BuscarRecursivo(Raiz, valor);

    private bool BuscarRecursivo(Nodo raiz, int valor) {
        if (raiz == null) return false;
        if (raiz.Valor == valor) return true;
        return valor < raiz.Valor ? BuscarRecursivo(raiz.Izquierdo, valor) : BuscarRecursivo(raiz.Derecho, valor);
    }

    // --- Eliminación ---
    public void Eliminar(int valor) => Raiz = EliminarRecursivo(Raiz, valor);

    private Nodo EliminarRecursivo(Nodo raiz, int valor) {
        if (raiz == null) return null;

        if (valor < raiz.Valor) raiz.Izquierdo = EliminarRecursivo(raiz.Izquierdo, valor);
        else if (valor > raiz.Valor) raiz.Derecho = EliminarRecursivo(raiz.Derecho, valor);
        else {
            // Caso 1 y 2: Un hijo o ninguno
            if (raiz.Izquierdo == null) return raiz.Derecho;
            if (raiz.Derecho == null) return raiz.Izquierdo;

            // Caso 3: Dos hijos (Obtener el sucesor más pequeño a la derecha)
            raiz.Valor = ValorMinimo(raiz.Derecho);
            raiz.Derecho = EliminarRecursivo(raiz.Derecho, raiz.Valor);
        }
        return raiz;
    }

    // --- Recorridos ---
    public void Inorden(Nodo raiz) {
        if (raiz != null) {
            Inorden(raiz.Izquierdo);
            Console.Write(raiz.Valor + " ");
            Inorden(raiz.Derecho);
        }
    }

    public void Preorden(Nodo raiz) {
        if (raiz != null) {
            Console.Write(raiz.Valor + " ");
            Preorden(raiz.Izquierdo);
            Preorden(raiz.Derecho);
        }
    }

    public void Postorden(Nodo raiz) {
        if (raiz != null) {
            Postorden(raiz.Izquierdo);
            Postorden(raiz.Derecho);
            Console.Write(raiz.Valor + " ");
        }
    }

    // --- Métodos Extra ---
    public int ValorMinimo(Nodo raiz) {
        int minV = raiz.Valor;
        while (raiz.Izquierdo != null) {
            minV = raiz.Izquierdo.Valor;
            raiz = raiz.Izquierdo;
        }
        return minV;
    }

    public int ValorMaximo(Nodo raiz) {
        while (raiz.Derecho != null) raiz = raiz.Derecho;
        return raiz.Valor;
    }

    public int CalcularAltura(Nodo raiz) {
        if (raiz == null) return 0;
        return 1 + Math.Max(CalcularAltura(raiz.Izquierdo), CalcularAltura(raiz.Derecho));
    }

    public void Limpiar() => Raiz = null;
}