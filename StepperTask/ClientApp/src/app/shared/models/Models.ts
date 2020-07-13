export class Step {
  id: number;
  name: string;
  items: Item[];

  constructor() {
    this.id = null;
    this.name = null;
    this.items = []
  }
}

export class Item {
  id: number;
  title: string;
  description: string;
  stepId: number;

  constructor() {
    this.id = null;
    this.title = null;
    this.description = null;
    this.stepId = null;
  }
}
