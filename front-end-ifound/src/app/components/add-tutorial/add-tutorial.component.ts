import { Component, OnInit } from '@angular/core';
import { TutorialService } from 'src/app/services/tutorial.service';

@Component({
  selector: 'app-add-tutorial',
  templateUrl: './add-tutorial.component.html',
  styleUrls: ['./add-tutorial.component.css']
})
export class AddTutorialComponent implements OnInit {
  object = {
    ObjectName: '',
    ObjectDescription: '',
    ObjectStatus: '',
    ObjectPhoto: '',
    ObjectLostLocation: '',
    ObjectFoundLocation: '',
    ObjectCreationDate: '',
    ObjectLastUpdate: '',
    CategoryId: null,
    PersonWhoFoundId: null,
    PersonWhoLostId: null
  };
  submitted = false;

  constructor(private tutorialService: TutorialService) { }

  ngOnInit(): void {
  }

  saveTutorial(): void {
    const data = {
      ObjectName: this.object.ObjectName,
      ObjectDescription: this.object.ObjectDescription,
      ObjectStatus: this.object.ObjectStatus,
      ObjectPhoto: this.object.ObjectPhoto,
      ObjectLostLocation: this.object.ObjectLostLocation,
      ObjectFoundLocation: this.object.ObjectFoundLocation,
      ObjectCreationDate: this.object.ObjectCreationDate,
      ObjectLastUpdate: this.object.ObjectLastUpdate,
      CategoryId: this.object.CategoryId,
      PersonWhoFoundId: this.object.PersonWhoFoundId,
      PersonWhoLostId: this.object.PersonWhoLostId,
    };

    this.tutorialService.create(data)
      .subscribe(
        response => {
          console.log(response);
          this.submitted = true;
        },
        error => {
          console.log(error);
        });
  }

  newTutorial(): void {
    this.submitted = false;
    this.object = {
      ObjectName: '',
      ObjectDescription: '',
      ObjectStatus: '',
      ObjectPhoto: '',
      ObjectLostLocation: '',
      ObjectFoundLocation: '',
      ObjectCreationDate: '',
      ObjectLastUpdate: '',
      CategoryId: null,
      PersonWhoFoundId: null,
      PersonWhoLostId: null
    };
  }

}
