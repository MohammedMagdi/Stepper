import { Component, Inject } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { Step, Item } from '../shared/models/Models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  baseURL: string;
  steps: Step[] = [];
  viewStep: Step = new Step;
  addEditItem: Item = new Item;

  constructor(private apiService: ApiService, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }

  ngOnInit() {
    this.getAllSteps();
  }

  getAllSteps() {
    this.apiService.get(this.baseURL + 'Steps').subscribe(result => {
      this.steps = result;
      this.viewStep = this.steps[this.steps.length - 1];
      console.log(result);
    },
      error => {
        console.log(error);
        alert(error.message);
      });
  }

  changeStep(step: Step, event) {
    event.stopPropagation();
    this.viewStep = step;
    this.addEditItem = new Item;
  }

  addStep() {
    this.apiService.post(this.baseURL + 'Steps',{}).subscribe(result => {
      this.getAllSteps();
      alert('Step Added');
    },
      error => {
        console.log(error);
        alert(error.message);
      });
  }

  removeStep(step: Step, event) {
    event.stopPropagation();
    this.apiService.delete(this.baseURL + `Steps/${step.id}`).subscribe(result => {
      this.getAllSteps();
      alert('Step Deleted');
    },
      error => {
        console.log(error);
        alert(error.message);
      });
  }

  addNewItem(){
    let itemIndex = this.viewStep.items.length + 1;
    let StepIndex = this.steps.indexOf(this.viewStep) + 1;
    this.addEditItem = {id: null, title: `item ${itemIndex}`, description: `item ${itemIndex} from Step ${StepIndex} description`, stepId: this.viewStep.id};
  }

  editItem(item: Item, event) {
    event.stopPropagation();
    this.addEditItem = item;
  }

  removeItem(item: Item, event) {
     event.stopPropagation();
     this.apiService.delete(this.baseURL + `Item/${item.id}`).subscribe(result => {
      this.getAllSteps();
      alert('Item Deleted');
    },
      error => {
        console.log(error);
        alert(error.message);
      });
  }

  saveItem(){
    this.addEditItem.stepId = this.viewStep.id;
    if(this.validateItem()){
      if(!this.addEditItem.id){
        // add new
        this.apiService.post(this.baseURL + 'Item', this.addEditItem).subscribe(result => {
          this.getAllSteps();
          this.addEditItem = new Item;
          alert('Item Added');
        },
          error => {
            console.log(error);
            alert(error.message);
          });
      }
      else {
        // update
        this.apiService.put(this.baseURL + 'Item', this.addEditItem).subscribe(result => {
          this.getAllSteps();
          this.addEditItem = new Item;
          alert('Item Updated');
        },
          error => {
            console.log(error);
            alert(error.message);
          });
      }
    }
  }

  validateItem(){
    if(!this.addEditItem.title){
      alert('Title is Required');
      return false;
    }

    if(!this.addEditItem.description){
      alert('Description is Required');
      return false;
    }
    return true;
  }

  prevStep(){
    this.viewStep = this.steps[this.steps.indexOf(this.viewStep)-1];
  }

  nextStep(){
    this.viewStep = this.steps[this.steps.indexOf(this.viewStep)+1];
  }
}
