using System;
using System.Collections.Generic;

public class Solution {
    public int OrangesRotting(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshOranges = 0;
        int minutes = 0;
        
        // Step 1: Initialize the queue with all initially rotten oranges
        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) {
                    queue.Enqueue((r, c));  // Add all rotten oranges to the queue
                } else if (grid[r][c] == 1) {
                    freshOranges++;  // Count the number of fresh oranges
                }
            }
        }

        // Directions for moving up, down, left, right
        int[][] directions = new int[][] {
            new int[] {0, 1},  // right
            new int[] {1, 0},  // down
            new int[] {0, -1}, // left
            new int[] {-1, 0}  // up
        };

        // Step 2: Perform BFS to rot the fresh oranges
        while (queue.Count > 0 && freshOranges > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var (r, c) = queue.Dequeue();

                // Try all 4 possible directions
                foreach (var direction in directions) {
                    int newRow = r + direction[0];
                    int newCol = c + direction[1];

                    // If the new cell is within bounds and contains a fresh orange
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols && grid[newRow][newCol] == 1) {
                        grid[newRow][newCol] = 2;  // Rot the fresh orange
                        freshOranges--;  // Decrease the count of fresh oranges
                        queue.Enqueue((newRow, newCol));  // Add it to the queue for further processing
                    }
                }
            }
            minutes++;  // Increment the time after each BFS level
        }

        // Step 3: Return the result
        if (freshOranges == 0) {
            return minutes;  // All fresh oranges have been rotted
        } else {
            return -1;  // There are still fresh oranges that can't be rotted
        }
    }
}
