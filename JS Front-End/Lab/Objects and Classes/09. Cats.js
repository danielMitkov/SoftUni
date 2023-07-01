function PrintCatClass(data) {
    class Cat {
        constructor(name, age) {
            this.name = name;
            this.age = age;
        }
        meow() {
            console.log(`${this.name}, age ${this.age} says Meow`);
        }
    }
    for (let str of data) {
        let [name, age] = str.split(` `);
        new Cat(name, age).meow();
    }
}