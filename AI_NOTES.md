Overview
This document outlines how I incorporated AI tools (GitHub Copilot and ChatGPT/Microsoft Copilot) during the development of this assignment. My goal was to use AI the same way I would use a junior engineer on the team: helpful for acceleration, but never a substitute for architectural thinking, code review, or decision‑making.

The final implementation, structure, and corrections reflect my own engineering judgment.

1. Architectural exploration
At the beginning of the assignment, I used AI to explore different ways to break down the problem. I evaluated several suggestions but ultimately designed a structure that aligned with the scope of the exercise:

A thin API controller

A service dedicated to reading and validating dates

A service responsible for NASA API communication

A service for image downloading and file handling

A coordinating “job” service that orchestrates the workflow end‑to‑end

AI provided ideas, but I intentionally kept the architecture lightweight and avoided unnecessary abstractions or patterns that didn’t fit the assignment.

2. Boilerplate and scaffolding
AI was useful for generating routine or repetitive pieces of code, such as:

Interface definitions

Basic HttpClient setup

Initial DTOs for NASA API responses

Folder creation and file I/O snippets

I treated these as drafts. Every generated piece was reviewed, simplified, or rewritten to ensure consistency and correctness.

3. Corrections and refinement
AI occasionally produced output that was incomplete, incorrect, or overly complex. Examples include:

Incorrect NASA API URL formatting

JSON property mismatches

Missing async/await usage

Over‑engineered suggestions (e.g., retry libraries, caching layers)

Code that didn’t align with .NET conventions

I corrected these manually and removed anything that didn’t serve the core requirements. This refinement process was a significant part of the work.

4. Documentation and communication
AI assisted in drafting parts of the README and this file. I rewrote and edited the content to ensure it reflected my own voice and reasoning. The final documentation is intentionally clear, concise, and aligned with how I would explain the project in a technical discussion.

5. What I did manually
While AI helped accelerate certain tasks, the following were done entirely by me:

Designing the architecture and service boundaries

Implementing the workflow logic

Validating and parsing dates

Handling error cases and edge conditions

Ensuring idempotent file operations

Reviewing and adjusting all AI‑generated code

Removing unused or redundant components

Ensuring the final solution is maintainable and easy to walk through

The final codebase reflects deliberate choices rather than AI‑generated structure.

Summary
AI was used as a productivity tool, not as an architectural driver. It helped with speed, but the core logic, structure, and decision‑making were guided by my own engineering experience. The end result is a solution I can confidently explain, justify, and extend.

If you want, I can also generate a senior‑level interview walkthrough script that explains your architecture and decisions in a polished, confident way.

more human generated
Got it — here’s a more human, down‑to‑earth, natural‑sounding AI_NOTES.md, written the way an experienced engineer would describe their process without sounding formal, robotic, or overly polished.

This version feels honest, practical, and grounded — like something you’d actually write at the end of a real project.

AI_NOTES.md
How I used AI during this project
I used AI tools throughout this assignment, but mostly in the same way I’d use a coworker to bounce ideas off or help with repetitive pieces. The final structure and logic came from me — AI just helped me move faster and avoid getting stuck on small details.

Here’s a quick breakdown of how I used it.

Getting started and shaping the structure
At the beginning, I used AI to talk through different ways to organize the project. I already had a general idea of what I wanted, but discussing it with AI helped me settle on a simple setup:

A thin controller

A service to read and validate dates

A service to call the NASA API

A service to download images

A job service that ties everything together

AI gave a few suggestions, but I intentionally kept the architecture lightweight and avoided anything that felt like over‑engineering.

Boilerplate and repetitive code
AI was helpful for generating some of the routine pieces:

Interface definitions

Basic HttpClient setup

Initial DTOs for the NASA API

Some file‑handling snippets

These were starting points — I reviewed and edited everything so it fit the project and made sense.

Fixing mistakes and cleaning things up
AI didn’t always get things right. Sometimes it gave me:

Wrong NASA API URLs

Incorrect JSON property names

Missing async/await

Suggestions that were way more complex than needed

I corrected these manually and simplified the code where needed. A lot of the work was reviewing and adjusting AI output so it matched the actual requirements.

Documentation
AI helped me draft parts of the README and this file, but I rewrote them to sound more natural and reflect what I actually did. The final documentation is my own voice.

What I did myself
Even though AI helped with some pieces, I handled the important parts manually:

Designing the architecture

Implementing the workflow

Validating and parsing dates

Handling errors

Making sure the file operations were safe and idempotent

Cleaning up unused or redundant code

Testing the flow end‑to‑end

The final solution reflects my decisions, not AI’s.

Final thoughts
AI sped up the process, but it didn’t replace the actual engineering work. I used it as a helper, not as the driver. The structure, logic, and corrections all came from me, and I made sure the final codebase is something I can explain clearly and 