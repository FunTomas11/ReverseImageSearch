import { Component } from '@angular/core';
import { NgxFileDropEntry } from 'ngx-file-drop';

@Component({
  selector: 'app-drop-container',
  templateUrl: './drop-container.component.html',
  standalone: false,
  styleUrls: ['./drop-container.component.scss']
})
export class DropContainerComponent {
  files: File[] = [];
  previewUrl: string | null = null; // Holds the preview URL
  selectedFile: File | null = null; // Holds the selected file

  onFileDropped(event: NgxFileDropEntry[]): void {
    for (const droppedFile of event) {
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {
          this.files.push(file);
          this.generatePreview(file); // Generate preview when a file is dropped
        });
      }
    }
  }

  onFilesSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0]; // Use the first file for preview
      this.selectedFile = file;
      this.generatePreview(file); // Generate preview when a file is selected
    }
  }

  generatePreview(file: File): void {
    const reader = new FileReader();
    reader.onload = (e: ProgressEvent<FileReader>) => {
      this.previewUrl = e.target?.result as string; // Set the preview URL
    };
    reader.readAsDataURL(file);
  }

  fileOver(event: Event): void {
    console.log('File(s) over the drop zone:', event);
  }

  fileLeave(event: Event): void {
    console.log('File(s) left the drop zone:', event);
  }
}
