import { Component, OnInit } from '@angular/core';
import { TutorialService } from 'src/app/services/tutorial.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tutorial-details',
  templateUrl: './tutorial-details.component.html',
  styleUrls: ['./tutorial-details.component.css']
})
export class TutorialDetailsComponent implements OnInit {
  object = null;
  message = '';

  constructor(
    private tutorialService: TutorialService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit(): void {
    this.message = '';
    this.getTutorial(this.route.snapshot.paramMap.get('id'));
  }

  getTutorial(id): void {
    this.tutorialService.get(id)
      .subscribe(
        data => {
          this.object = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  updatePublished(status): void {
    const data = {
      title: this.object.title,
      description: this.object.description,
      published: status
    };

    this.tutorialService.update(this.object.Object.ObjectId, data)
      .subscribe(
        response => {
          console.log(response);
        },
        error => {
          console.log(error);
        });
  }

  updateTutorial(): void {
debugger;
    const data = {
      ObjectId: this.object[0].Object.ObjectId,
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
    this.tutorialService.update(this.object[0].Object.ObjectId, data)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'Informações alteradas com sucesso!';
        },
        error => {
          console.log(error);
        });
  }

  // deleteTutorial(): void {
  //   this.tutorialService.delete(this.currentTutorial.id)
  //     .subscribe(
  //       response => {
  //         console.log(response);
  //         this.router.navigate(['/tutorials']);
  //       },
  //       error => {
  //         console.log(error);
  //       });
  // }
}
