class Program {
    static void Main() {
        ArbolBinario bst = new ArbolBinario();
        int opcion, valor;

        do {
            Console.WriteLine("\n--- ÁRBOL BINARIO DE BÚSQUEDA ---");
            Console.WriteLine("1. Insertar   2. Buscar      3. Eliminar");
            Console.WriteLine("4. Recorridos 5. Estadísticas 6. Limpiar");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            if (!int.TryParse(Console.ReadLine(), out opcion)) continue;

            switch (opcion) {
                case 1:
                    Console.Write("Valor a insertar: ");
                    valor = int.Parse(Console.ReadLine());
                    bst.Insertar(valor);
                    break;
                case 2:
                    Console.Write("Valor a buscar: ");
                    valor = int.Parse(Console.ReadLine());
                    Console.WriteLine(bst.Buscar(valor) ? "Encontrado." : "No existe.");
                    break;
                case 3:
                    Console.Write("Valor a eliminar: ");
                    valor = int.Parse(Console.ReadLine());
                    bst.Eliminar(valor);
                    break;
                case 4:
                    Console.Write("\nInorden: "); bst.Inorden(bst.Raiz);
                    Console.Write("\nPreorden: "); bst.Preorden(bst.Raiz);
                    Console.Write("\nPostorden: "); bst.Postorden(bst.Raiz);
                    Console.WriteLine();
                    break;
                case 5:
                    if (bst.Raiz == null) Console.WriteLine("Árbol vacío.");
                    else {
                        Console.WriteLine($"Mínimo: {bst.ValorMinimo(bst.Raiz)}");
                        Console.WriteLine($"Máximo: {bst.ValorMaximo(bst.Raiz)}");
                        Console.WriteLine($"Altura: {bst.CalcularAltura(bst.Raiz)}");
                    }
                    break;
                case 6:
                    bst.Limpiar();
                    Console.WriteLine("Árbol vacío ahora.");
                    break;
            }
        } while (opcion != 0);
    }
}