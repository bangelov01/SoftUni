# Linux Commands Spreadsheet

## User related commands

___

- `$ whoami` - displays the currently logged user
- `$ uname - a` - command to print OS information
- `$ top [options]` - display Linux processes
    - `$ top -d 2 -n 5` - display user's processes with 2 sec. delay 5 times

## File System commands

___

- [`$ ls [options]`](https://www.maths.cam.ac.uk/computing/linux/unixinfo/ls) - lists all files in the current dir except hidden files.
    - `$ ls -al` - lists a long list of files including hidden files
    - `$ ls /` - examine root directory files
- [`$ cat [options]`](https://www.geeksforgeeks.org/cat-command-in-linux-with-examples/) - reads data from a file and gives the content as output.
- `$ mkdir [options]`
    - `$ mkdir dir1 dir2` - creates two directories
    - `$ mkdir -pv projects/project1` - creates nested directory

## Input/Output streams

___

- `stdin` - standard **input** stream = 0
    - `$ cat hello.txt` == `$ cat < hello.txt` - reads the file content
- `stdout` - standard **output** stream = 1
    - `$ echo 'Hello World!' > hello.txt` == `$ echo 'Hello World!' 1> hello.txt` - writes Hello World! to a hello.txt file
    - `$ echo 'Hello World!' >> hello.txt` - appends Hello World! to hello.txt file
- `stderr` - standard **error output** stream = 2 - throws an error as output

## Command sequences

___

- Sequence - command1 ; command2 (executes in order(disconnected))
    - `$ ls non-existing-file.txt ; echo Ok` - error that no file exists, still prints OK
- Pipe - command1 | command2 (executes in order(connected))
    - `$ ls | sort | head -n 3` - lists all files, sorts, and shows first 3 items
- Conditional
    - On Success - command1 && command2
        - `$ ls non-existing-file.txt && echo Ok` - not executed
        - `$ ls existing-file.txt && echo Ok` - executed
    - On Failure - command1 || command2 - opposite of latter

## Users

___

- `/etc/passwd` - users file
- `/etc/group` - groups file

## Rights

___

- `rwx` - r=4;w=2;x=1

- `---------` - 000 - no permissions
- `rw-rw-rw-` - 666 - everyone read + write
- `rwxr-xr-x` - 755 - owner full access, others read and write
- `rwxrwxrwx` - 777 - all permissions on everyone

- `$ sudo` - allows a given user to act as an administrator/root user. Privilege to use `sudo` must be granted to the user i.e. entry in `/etc/sudoers` folder
    - `$ sudo -u testuser whoami` - prints `whoami` as testuser
    - `$ sudo su testuser` - switches to testuser
    - `$ sudo chmod +x hello.txt` - executes a single command as root
- `$ chmod -r hello.txt` - changes hello.txt permissions to have read
- `$ chown [options] [owner][:[group]] fileName`
    - `$ chown user:users file.txt` - changes both owner and the group of the file
- `$ chgrp [options] groupFile`
    - `$ chgrp developers file.txt` - changes the group of file.txt to developers

## More commands

___

- `$ apt` - provides a high-level command line interface for the package
management system
    - `$ apt install <package>`
    - `$ apt update` - updates information on all available packages
    - `$ apt upgrade` - upgrades all packages on the system

- `$ touch [options] file` - changes file timestamp

- `$ cp [options] source destination`
    - `$ cp file1.txt ~/dir1/file2.txt` - copis single file
    - `$ cp /etc/*.conf ~/dir2` - copis multiple files

- `$ mv [options] source destination` - move(rename)
    -`$ mv file1.txt first-file.txt` - renames file1.txt
    - `$ $ mv *.txt ~/TextFiles` - moves all files

- `$ rm [options] file`
    - `$ rm file.txt` - removes file.txt
    - `$ rm -rf ~/TextFiles` - removes TextFiles folder and its contents

- `$ pwd` - prints current working directory

- `$ jobs [options] jobspec` - displays status of jobs
    - `$ jobs -l` displays all jobs with detailed info.

- `$ ps [options]` - report a snapshot of the current processes
- `$ kill [options] pid | jobspec` - send a signal to a job or process e.g SIGKILL
    - `$ sudo kill -l` - lists all signals
- `$ killall [options] process`
    - `$ killall -9 bash` - sends a SIGKILL to all bash processes

- `$ curl [options] URL` - fetches the headers from the URL