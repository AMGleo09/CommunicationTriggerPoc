import { Component, NgModule } from '@angular/core';
import { CommunicationLog } from './models/communication-log.model';
import { CommunicationService } from './services/communication-service';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';


@Component({
  selector: 'app-communication',
  imports: [CommonModule,FormsModule,ReactiveFormsModule],
  templateUrl: './communication.html',
  styleUrl: './communication.css',
})
export class Communication {

  // claimNumber: string = '';
  form: FormGroup;
  logs: CommunicationLog[] = [];
  loading = false;

  // constructor(private commService: CommunicationService) {}

   constructor(private fb: FormBuilder, private commService: CommunicationService) {
    // ✅ initialize FormGroup
    this.form = this.fb.group({
      claimNumber: ['']
    });
  }

  // fetchLogs() {
  //   this.loading = true;
  //   this.commService.getLogs(this.claimNumber).subscribe({
  //     next: (data) => {
  //       this.logs = data;
  //       this.loading = false;
  //     },
  //     error: () => {
  //       alert('Error fetching logs');
  //       this.loading = false;
  //     }
  //   });
  // }

  // retrigger(logId: number) {
  //   this.commService.retrigger(logId).subscribe({
  //     next: () => {
  //       alert('Retriggered successfully!');
  //       this.fetchLogs(); // refresh logs
  //     },
  //     error: () => alert('Retrigger failed')
  //   });
  // }

  fetchLogs() {
    const claimNumber = this.form.get('claimNumber')?.value;
    if (!claimNumber) {
      alert('Please enter a Claim Number');
      return;
    }

    this.loading = true;
    this.commService.getLogs(claimNumber).subscribe({
      next: (data) => {
        this.logs = data;
        this.loading = false;
      },
      error: () => {
        alert('Error fetching logs');
        this.loading = false;
      }
    });
  }

  retrigger(logId: number) {
    this.commService.retrigger(logId).subscribe({
      next: () => {
        alert('Retriggered successfully!');
        this.fetchLogs(); // refresh logs
      },
      error: () => alert('Retrigger failed')
    });
  }

}
